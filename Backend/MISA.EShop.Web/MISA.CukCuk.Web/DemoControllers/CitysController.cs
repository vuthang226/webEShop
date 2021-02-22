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
    public class CitysController : ControllerBase
    {

        IDbContext<City> _idbContext;
        public CitysController(IDbContext<City> idbContext)
        {
            
            _idbContext = idbContext;
        }
        // GET: api/<CitysController>
        [HttpGet]
        public IEnumerable<City> Get()
        {
            return _idbContext.GetData("Proc_GetCitys", CommandType.StoredProcedure);
        }

        // GET api/<CitysController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CitysController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CitysController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CitysController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
