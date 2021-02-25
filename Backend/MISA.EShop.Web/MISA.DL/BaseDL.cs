using Dapper;
using MISA.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.DL
{
    public class BaseDL<TEntity>
    {
        IDbContext<TEntity> _dbContext;
        public BaseDL(IDbContext<TEntity> dbContext){
            _dbContext = dbContext;

        }
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Toàn bộ dữ liệu</returns>
        /// VHTHANG 20/2/1021
        public IEnumerable<TEntity> GetAll()
        {
            var entity = _dbContext.GetAll();
            return entity;
        }



        /// <summary>
        /// Thêm một bản ghi
        /// </summary>
        /// <param name="entity">Object truyền vào</param>
        /// <returns>ServiceResult</returns>
        /// VHTHANG 20/2/1021
        public int Insert(TEntity entity)
        {
            int rowAffect = _dbContext.Insert(entity);
            return rowAffect;                                                                                                     
        }

       

        /// <summary>
        /// Update dữ liệu theo Id
        /// </summary>
        /// <param name="entity">Object truyền vào</param>
        /// <returns>ServiceResult</returns>
        /// VHTHANG 20/2/1021
        public int Update(TEntity entity)
        {
            int rowAffect = _dbContext.Update(entity);
            return rowAffect;
        }

        public int Delete(TEntity entity)
        {
            int rowAffect = _dbContext.Delete(entity);
            return rowAffect;
        }

        

        public IEnumerable<TEntity> CheckDuplicate(string name, string value)
        {
            var tableName = typeof(TEntity).Name;
            var entity = _dbContext.GetData($"SELECT * FROM {tableName} AS S WHERE S.{name} = '{value}'");
            return entity;
        }

        /// <summary>
        /// Hàm lấy dữ liệu đã đc sắp xếp theo từng trang
        /// </summary>
        /// <param name="page">Số trang</param>
        /// <param name="filter">Cách sắp</param>
        /// <param name="desc">Tăng hay giảm dần</param>
        /// <returns></returns>
        /// Modified by VHTHANG 20/2/2021
        public IEnumerable<TEntity> GetShopSortPage(int page, string filter, int desc)
        {
            //Hàm có thể tạo base để đưa ra dùng chung
            var tableName = typeof(TEntity).Name;
            var numOfPage = 20;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@id", filter);
            dynamicParameters.Add($"@startFrom", (page - 1) * numOfPage);
            dynamicParameters.Add($"@num", numOfPage);
            dynamicParameters.Add($"@desc1", desc);
            var entities = _dbContext.GetData($"Proc_Get{tableName}FilterPage", dynamicParameters, CommandType.StoredProcedure);
            return entities;
        }
    }
}
