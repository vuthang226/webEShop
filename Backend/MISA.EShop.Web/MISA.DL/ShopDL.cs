using Dapper;
using MISA.Common;
using MISA.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.DL
{
    public class ShopDL: IShopDL
    {
        #region DECLARE
        IDbContext<Shop> _dbContext;
        public ShopDL(IDbContext<Shop> dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region METHODS
        /// <summary>
        /// Lấy Mã code cao nhất
        /// </summary>
        /// <returns>Mã code cao nhất</returns>
        /// Modified by VHTHANG 20/2/2021
        public string GetHighestCode()
        {
            var entity = _dbContext.GetData($"SELECT ShopCode FROM Shop Order By ShopCode DESC Limit 1").ElementAt(0).ShopCode.ToString();
            return entity;
        }
        public IEnumerable<Shop> CheckDuplicate(string name, string value)
        {
            var shop = _dbContext.GetData($"SELECT * FROM Shop AS S WHERE S.{name} = '{value}'");
            return shop;
        }

        /// <summary>
        /// Hàm lấy dữ liệu đã đc sắp xếp theo từng trang
        /// </summary>
        /// <param name="page">Số trang</param>
        /// <param name="filter">Cách sắp</param>
        /// <param name="desc">Tăng hay giảm dần</param>
        /// <returns></returns>
        /// Modified by VHTHANG 20/2/2021
        public IEnumerable<Shop> GetShopSortPage(int page, string filter, int desc)
        {
            //Hàm có thể tạo base để đưa ra dùng chung
            var tableName = typeof(Shop).Name;
            var numOfPage = 20;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@id", filter);
            dynamicParameters.Add($"@startFrom", (page - 1) * numOfPage);
            dynamicParameters.Add($"@num", numOfPage);
            dynamicParameters.Add($"@desc1", desc);
            var shops = _dbContext.GetData($"Proc_Get{tableName}FilterPage", dynamicParameters, CommandType.StoredProcedure);
            return shops;
        }

        #endregion
    }
}
