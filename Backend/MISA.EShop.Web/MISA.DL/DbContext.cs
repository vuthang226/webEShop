using Dapper;
using MISA.DL.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.DL
{
    public class DbContext<TEntity>:IDbContext<TEntity>
    {
        #region DECLARE
        //Khởi tạo
        protected string _connectionString = "Host=47.241.69.179;User Id=dev; password=12345678;Database=MF727_VHTHANG_CukCuk;port=3306;Character Set=utf8";
        protected IDbConnection _dbConnection;
        public DbContext()
        {
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Lấy dữ liệu theo nhiều tiêu chí
        /// </summary>
        /// <typeparam name="TEntity">Loại đối tượng</typeparam>
        /// <param name="sqlCommand">Câu lệnh sql hoặc tên store</param>
        /// <param name="parameters">đối tượng chứa thông tin tham số của strore</param>
        /// <param name="commandType">Mặc định CommandType.Text</param>
        /// <returns></returns>
        /// Modified by VHTHANG 20/2/2021
        public IEnumerable<TEntity> GetData(string sqlCommand = null,object parameters = null, CommandType commandType = CommandType.Text)
        {
            var tableName = typeof(TEntity).Name;
            if(sqlCommand == null)
            {
                sqlCommand = $"Proc_Get{tableName}s";
            }           
            var entity = _dbConnection.Query<TEntity>(sqlCommand,param: parameters, commandType: commandType);
            return entity;
        }

        /// <summary>
        /// Thêm mới bản ghi dữ liệu
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity">Bản ghi truyền vào</param>
        /// <returns>Số bản ghi được thêm</returns>
        /// Modified by VHTHANG 20/2/2021
        public int Insert(TEntity entity)
        {
            var tableName = typeof(TEntity).Name;
            var storeName = $"Proc_Insert{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            var properties = typeof(TEntity).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    dynamicParameters.Add($"@{propertyName}", propertyValue, DbType.String);
                }
                else
                {
                    dynamicParameters.Add($"@{propertyName}", propertyValue);
                }
            }
            var query = _dbConnection.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return query;
        }

        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Dữ liệu</returns>
        /// Modified by VHTHANG 20/2/2021
        public IEnumerable<TEntity> GetAll() 
        {
            var tableName = typeof(TEntity).Name;
            //var entities = _dbConnection.Query<TEntity>($"Proc_Get{tableName}s", commandType: CommandType.Text);
            var entities = _dbConnection.Query<TEntity>($"SELECT * FROM {tableName} LIMIT 20", commandType: CommandType.Text);
            return entities;
        
        }

        /// <summary>
        /// Chỉnh sủa dữ liệu theo id
        /// </summary>
        /// <param name="entity">Đối tượng truyền vào</param>
        /// <returns>Số bản ghi đã chỉnh</returns>
        /// Modified by VHTHANG 20/2/2021
        public int Update(TEntity entity)
        {
            var tableName = typeof(TEntity).Name;
            var storeName = $"Proc_Update{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            var properties = typeof(TEntity).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    dynamicParameters.Add($"@{propertyName}", propertyValue, DbType.String);
                }
                else
                {
                    dynamicParameters.Add($"@{propertyName}", propertyValue);
                }


            }
            var query = _dbConnection.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return query;
        }

        /// <summary>
        /// Xóa dữ liệu theo id
        /// </summary>
        /// <param name="entity">dữ liệu</param>
        /// <returns>Số bản ghi đã bị xóa</returns>
        /// Modified by VHTHANG 20/2/2021
        public int Delete(TEntity entity)
        {
            var tableName = typeof(TEntity).Name;
            var sqlString = $"DELETE FROM {tableName} WHERE {tableName}Id = @{tableName}Id";
            var query = _dbConnection.Execute(sqlString, entity, commandType: CommandType.Text);
            return query;
        }
        #endregion

    }
}
