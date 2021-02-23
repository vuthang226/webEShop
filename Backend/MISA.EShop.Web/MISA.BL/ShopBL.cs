using MISA.BL.Interfaces;
using MISA.Common;
using MISA.Common.Entities;
using MISA.Common.Properties;
using MISA.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISA.BL
{
    public class ShopBL : BaseBL<Shop>, IShopBL
    {
        #region DECLARE
        IShopDL _shopDL;
        IDbContext<Shop> _dbContext;
        public ShopBL(IDbContext<Shop> dbContext, IShopDL ShopDL) : base(dbContext)
        {
            _shopDL = ShopDL;
            _dbContext = dbContext;
        }
        #endregion

        #region METHODS
        /// <summary>
        /// Lấy mã code cao nhất
        /// </summary>
        /// <returns></returns>
        public override string GetHighestCodeAddOne()
        {
            var codeMax = _shopDL.GetHighestCode();
            string a = codeMax.Substring(codeMax.Length - 5, 5);
            int i = int.Parse(a);
            i = i + 1;
            var stringg = "";
            if (i < 10) { stringg = "CH00000" + i.ToString(); }
            else if (i < 100) { stringg = "CH0000" + i.ToString(); }
            else if (i < 1000) { stringg = "CH000" + i.ToString(); }
            else if (i < 10000) { stringg = "CH00" + i.ToString(); }
            else if (i < 100000) { stringg = "CH0" + i.ToString(); }
            else { stringg = "CH" + i.ToString(); }
            return stringg;

        }

        /// <summary>
        /// Overrride hàm kiểm tra dữ liệu
        /// </summary>
        /// <param name="shop">Khách hàng</param>
        /// <returns>ServiceResult</returns>
        protected override ServiceResult Validate(Shop shop,int type)
        {
            var serviceResult = new ServiceResult();
            var shopCode = shop.ShopCode;
            //Kiểm tra mã có bị để trống
            if (string.IsNullOrEmpty(shopCode) || string.IsNullOrEmpty(shopCode.Trim()))
            {
                var msg = new
                {
                    devMsg = new { Messenger = Resources.ErroService_EmptyEmployeeCode },
                    userMsg = Resources.ErroService_EmptyEmployeeCode,
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = Resources.ErroService_EmptyEmployeeCode;
                serviceResult.Data = msg;
                return serviceResult;
            }
            //Kiểm tra trùng mã
            var checkCode = _shopDL.CheckDuplicate("ShopCode", shop.ShopCode);
            if (checkCode.Count() > 0)
            {
                if (type == 1 || checkCode.ElementAt(0).ShopId != shop.ShopId) {
                    var msg = new
                    {
                        devMsg = new { Messenger = Resources.ErroService_DuplicateShopCode },
                        userMsg = Resources.ErroService_DuplicateShopCode,
                    };
                    serviceResult.MISACode = MISACode.NotValid;
                    serviceResult.Messenger = Resources.ErroService_DuplicateShopCode;
                    serviceResult.Data = msg;
                    return serviceResult;
                }
            }
            serviceResult.MISACode = MISACode.IsValid;
            serviceResult.Messenger = Resources.SuccessService_IsVaid;
            serviceResult.Data = 1;
            return serviceResult;

        }


        /// <summary>
        /// Lấy dữ liệu bằng proc theo trang cùng sắp xếp dữ liệu
        /// </summary>
        /// <param name="page">Số trang</param>
        /// <param name="filter">Cách sắp</param>
        /// <param name="desc">Tăng hay giảm dần</param>
        /// <returns></returns>
        public IEnumerable<Shop> GetShopSortPage(int page, string filter, int desc)
        {
            var shops = _shopDL.GetShopSortPage(page,filter,desc);
            return shops;
        }
        #endregion
    }
}
