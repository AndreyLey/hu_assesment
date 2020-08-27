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

namespace Form_Builder.Controllers
{
    [Route("")]
    [ApiController]
    public class FormsController : ControllerBase
    {
        private readonly IFormManager _formManager;

        public FormsController(IFormManager formManager)
        {
            _formManager = formManager;
        }

        // GET: forms/1
        [HttpGet ("forms/{id}")]
        public IActionResult Get(string id)
        {
            return new JsonResult(_formManager.GetFormById(id));
        }

        // GET
        [HttpGet("forms")]
        public IActionResult Get()
        {
            return new JsonResult(_formManager.GetFormsSummary());
        }

        // POST
        [HttpPost("forms")]
        public void Post([FromBody] Form form)
        {
            _formManager.SaveForm(form);
        }

        // PUT
        [HttpPut("forms/{id}/submission")]
        public void Put( string id, [FromBody] Submission value)
        {
            _formManager.SaveSubmission(id, value);

        }

        [HttpGet("forms/{id}/submissions")]
        public IActionResult GetSubmissions(string id)
        {
            return new JsonResult(_formManager.GetSubmissionsByFormId(id));

        }

        [HttpGet("types")]
        public IActionResult GetTypes()
        {
            return new JsonResult(_formManager.GetTypes());
        }
    }
}
