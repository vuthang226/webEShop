
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

        //[HttpGet("codes")]
        //public IEnumerable<Shop> Get(string code, int aa)
        //{
        //    DynamicParameters dynamicParameters = new DynamicParameters();
        //    dynamicParameters.Add($"@id", "ShopName");
        //    return _idbContext.GetData("procedure1", dynamicParameters, CommandType.StoredProcedure);
        //}
    }
}
