using ApiReadXml.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiReadXml.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InputDocumentController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] InputDocument input)
        {
            try
            {
                if (input != null)
                {
                    if (input?.DeclarationList?.Declaration?.Command.ToLower() != "default")
                    {
                        return BadRequest(new { status = -1, message = "Invalid command specified." });
                    }
                    else if (input?.DeclarationList?.Declaration?.DeclarationHeader?.SiteID?.ToLower() != "dub")
                    {
                        return BadRequest(new { status = -2, message = "Invalid Site specified." });
                    }

                    return Ok(new { status = 0, message = "The document was structured correctly." });
                }
                else
                {
                    return BadRequest(new { status = "error", message = "Invalid XML." });
                    }
            }
            catch (System.Exception e)
            {
                return BadRequest(new { status = "error", message = e.Message });
            }
        }
    }
}
