using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExcelTeamplate.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ExcelTeamplate.Controllers
{
    [Route("api/[controller]")]
    public class ExcelController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post()
        {
            //var fields = HttpContextHelper.GetString(HttpContext, "fields");
            var file = HttpContext.Request.Form.Files[0];
            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
