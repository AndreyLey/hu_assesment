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
    public class FormsController : ControllerBase
    {
        private readonly IFormManager _formManager;

        public FormsController(IFormManager formManager)
        {
            _formManager = formManager;
        }

        // GET: forms/1
        [HttpGet ("{id}")]
        public IActionResult Get(string id)
        {
            return new JsonResult(_formManager.GetFormById(id));
            //return new string[] { "value1", "value2" };

        }


        // GET forms
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_formManager.GetFormsSummary());
        }

        // POST forms
        [HttpPost]
        public void Post([FromBody] Form form)
        {
            _formManager.SaveForm(form);
            //var request = HttpContext.Request.Body.ToString();
            //var converted = JsonConvert.DeserializeObject<Form>(request);
        }

        // PUT forms/1
        [HttpPut("{id}/submission")]
        public void Put( string id, [FromBody] Submission value)
        {
            _formManager.SaveSubmission(id, value);

        }

        [HttpGet("{id}/submissions")]
        public IActionResult GetSubmissions(string id)
        {
            return new JsonResult(_formManager.GetSubmissionsByFormId(id));

        }
        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
