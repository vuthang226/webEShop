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
    public class DistrictsController : ControllerBase
    {

        IDbContext<District> _idbContext;
        public DistrictsController(IDbContext<District> idbContext)
        {

            _idbContext = idbContext;
        }
        // GET: api/<CitysController>
        [HttpGet]
        public IEnumerable<District> Get(string id)
        {

            return _idbContext.GetData("Proc_GetDistrictById",new { id = id}, CommandType.StoredProcedure);
        }
        

        // GET api/<DistrictsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DistrictsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DistrictsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DistrictsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
