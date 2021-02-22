using MISA.Common;
using MISA.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISA.DL
{
    public class ShopDL: IShopDL
    {
        IDbContext<Shop> _dbContext;
        public ShopDL(IDbContext<Shop> dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Lấy Mã code cao nhất
        /// </summary>
        /// <returns>Mã code cao nhất</returns>
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
    }
}
