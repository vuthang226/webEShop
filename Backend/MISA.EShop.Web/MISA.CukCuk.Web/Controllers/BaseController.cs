using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.BL.Interfaces;
using MISA.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<TEntity> : ControllerBase
    {
        IBaseBL<TEntity> _baseBL;
        public BaseController(IBaseBL<TEntity> baseBL)
        {
            _baseBL = baseBL;
        }

        /// <summary>
        /// Lấy toàn bộ dữ liệu 
        /// </summary>
        /// <returns>Trạng thái và dữ liệu</returns>
        /// VHTHANG 20/2/1021
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_baseBL.GetAll());
        }



        /// <summary>
        /// Thêm mới dữ liệu có check dữ liệu trùng
        /// </summary>
        /// <param name="entity">Dữ liệu truyền vào</param>
        /// <returns>Status</returns>
        /// VHTHANG 20/2/1021
        [HttpPost]
        public IActionResult Post(TEntity entity)
        {
            var serviceResult = _baseBL.Insert(entity);
            if (serviceResult.MISACode == MISACode.NotValid)
            {
                return BadRequest(serviceResult.Data);
            }
            if (serviceResult.MISACode == MISACode.Success && (int)serviceResult.Data > 0)
            {
                return Created("Success", serviceResult.Messenger);
            }
            else return NoContent();
        }

        /// <summary>
        /// Nhân bản dữ liệu
        /// </summary>
        /// <param name="entity">Dữ liệu muốn nhân bản</param>
        /// <param name="code"></param>
        /// <returns></returns>
        /// VHTHANG 20/2/1021
        [HttpPost("clone")]
        public IActionResult Post(TEntity entity,int code = 1)
        {
            var serviceResult = _baseBL.Clone(entity);
            if (serviceResult.MISACode == MISACode.NotValid)
            {
                return BadRequest(serviceResult.Data);
            }
            if (serviceResult.MISACode == MISACode.Success && (int)serviceResult.Data > 0)
            {
                return Created("Success", serviceResult.Messenger);
            }
            else return NoContent();
        }

        /// <summary>
        /// Update dữ liệu
        /// </summary>
        /// <param name="entity">dữ liệu đã chỉnh sửa</param>
        /// <returns></returns>
        /// VHTHANG 20/2/1021
        [HttpPut]
        public IActionResult Put(TEntity entity)
        {
            var serviceResult = _baseBL.Update(entity);
            if (serviceResult.MISACode == MISACode.NotValid)
            {
                return BadRequest(serviceResult.Data);
            }
            if (serviceResult.MISACode == MISACode.Success && (int)serviceResult.Data > 0)
            {
                return Created("Success", serviceResult.Messenger);
            }
            else return NoContent();
        }

        /// <summary>
        /// Xóa dữ liệu theo id
        /// </summary>
        /// <param name="entity">Dữ liệu cần xóa</param>
        /// <returns>trả về thông báo</returns>
        /// VHTHANG 20/2/1021
        [HttpDelete]
        public IActionResult Delete(TEntity entity)
        {
            var serviceResult = _baseBL.Delete(entity);
            if (serviceResult.MISACode == MISACode.NotValid)
            {
                return BadRequest(serviceResult.Data);
            }
            if (serviceResult.MISACode == MISACode.Success && (int)serviceResult.Data > 0)
            {
                return Created("Success", serviceResult.Messenger);
            }
            else return NoContent();
        }

    }
}
