using Microsoft.AspNetCore.Mvc;
using MISA.Common;
using MISA.Common.DemoArea;
using MISA.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Web.DemoControllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WardsController : ControllerBase
    {
        IDbContext<Ward> _idbContext;
        public WardsController(IDbContext<Ward> idbContext)
        {

            _idbContext = idbContext;
        }
        // GET: api/<CitysController>
        [HttpGet]
        public IEnumerable<Ward> Get(string id)
        {

            return _idbContext.GetData("Proc_GetWardById", new { id = id }, CommandType.StoredProcedure);
        }

        // GET api/<WardsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<WardsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WardsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WardsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
