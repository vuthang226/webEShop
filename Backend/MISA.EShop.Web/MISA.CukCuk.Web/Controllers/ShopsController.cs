

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.BL.Interfaces;
using MISA.Common;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ShopsController : BaseController<Shop>
    {
        IShopBL _shopBL;
        public ShopsController(IShopBL shopBL) : base(shopBL)
        {
            _shopBL = shopBL;
        }

        /// <summary>
        /// Lấy mã code cao nhất
        /// </summary>
        /// <returns>Mã code cao nhất trong csdl</returns>
        [HttpGet("code")]
        public string Get(string code)
        {
            return _shopBL.GetHighestCodeAddOne();
        }


        /// <summary>
        /// Lấy dữ liệu bằng proc theo trang cùng sắp xếp dữ liệu
        /// </summary>
        /// <param name="page">Số trang</param>
        /// <param name="filter">Cách sắp</param>
        /// <param name="desc">Tăng hay giảm dần</param>
        /// <returns></returns>
        [HttpGet("sort")]
        public IEnumerable<Shop> Get(int page, string filter,int desc)
        {
            return _shopBL.GetShopSortPage(page, filter, desc);
        }
    }
}
