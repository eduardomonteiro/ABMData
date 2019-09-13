using ABMData.Interfaces;
using ABMData.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ABMData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InputDocumentController : ControllerBase
    {
        InputDocumentInterface _iIutDocument;

        public InputDocumentController(InputDocumentInterface iIutDocument)
        {
            _iIutDocument = iIutDocument;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromBody] InputDocument xmlDoc)
        {
            try
            {
                return Ok(new { status = "success", result = await _iIutDocument.GetReferences(xmlDoc) });
            }
            catch (System.Exception e)
            {
                return BadRequest(new { status = "error", message = e.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InputDocument xmlDoc)
        {
            try
            {
                if (xmlDoc != null)
                {
                    return Ok(new { status = 0, message = await _iIutDocument.ValidateStatus(xmlDoc) });
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
