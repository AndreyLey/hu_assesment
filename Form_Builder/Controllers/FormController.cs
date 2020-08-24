using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Form_Builder.DB;
using Form_Builder.Model;
using Form_Builder.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Newtonsoft.Json;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Form_Builder.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly IFormManager _formManager;

        public FormController(IFormManager formManager)
        {
            _formManager = formManager;
        }

        // GET: form/1
        [HttpGet ("{id}")]
        public IActionResult Get(string id)
        {
            return new JsonResult(_formManager.GetFormById(id));
            //return new string[] { "value1", "value2" };

        }


        //// GET api/<ValuesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Form form)
        {
            _formManager.SaveForm(form);
            //var request = HttpContext.Request.Body.ToString();
            //var converted = JsonConvert.DeserializeObject<Form>(request);
        }

        // PUT form/1
        [HttpPut("{id}")]
        public void Put( string id, [FromBody] Submission value)
        {
            _formManager.SaveSubmission(id, value);

        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
