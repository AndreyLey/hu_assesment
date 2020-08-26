using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Form_Builder.DB;
using Form_Builder.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Form_Builder.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        IFormManager _formManager;
        public SubmissionController(IFormManager formManager)
        {
            _formManager = formManager;
        }
        // GET: api/<SubmissionController>
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_formManager.GetTypes());
        }

        // GET api/<SubmissionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SubmissionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SubmissionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SubmissionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
