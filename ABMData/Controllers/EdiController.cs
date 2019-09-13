using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ABMData.Interfaces;

namespace ABMData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EdiController : ControllerBase
    {
        EdiInterface _iEdi;

        public EdiController(EdiInterface iEdi)
        {
            _iEdi = iEdi;
        }
        //private static string body = "UNA:+.? 'UNB+UNOC:3+2021000969+4441963198+180525:1225+3VAL2MJV6EH9IX+KMSV7HMD+CUSDECU-IE++1++1'UNH+EDIFACT+CUSDEC:D:96B:UN:145050'BGM+ZEM:::EX+09SEE7JPUV5HC06IC6+Z'LOC+17+IT044100'LOC+18+SOL'LOC+35+SE'LOC+36+TZ'LOC+116+SE003033'DTM+9:20090527:102'DTM+268:20090626:102'DTM+182:20090527:102'";

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            try
            {
                using (var reader = new StreamReader(Request.Body))
                {
                    var body = reader.ReadToEnd();

                    return Ok(new { status = "success", result = await _iEdi.GetLocs(body) });
                }
            }
            catch (System.Exception)
            {
                return BadRequest(new { status = "error" });
            }
        }
    }
}
