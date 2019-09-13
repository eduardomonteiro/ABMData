using System.Collections.Generic;
using ABMData.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ABMData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuideController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            string baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/api/";
            List<Questions> questions = new List<Questions>();

            questions.Add(new Questions { QuestionNumber = 1, Url = string.Format("{0}edi/", baseUrl), Method = "POST" });
            questions.Add(new Questions { QuestionNumber = 2, Url = string.Format("{0}InputDocument/", baseUrl), Method = "GET" });
            questions.Add(new Questions { QuestionNumber = 3, Url = string.Format("{0}InputDocument/", baseUrl), Method = "POST" });

            return Ok(questions);
        }
    }
}
