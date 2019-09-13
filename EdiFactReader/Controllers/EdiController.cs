using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace EdiFactReader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EdiController : ControllerBase
    {
        //private static string ediData = "UNA:+.? 'UNB+UNOC:3+2021000969+4441963198+180525:1225+3VAL2MJV6EH9IX+KMSV7HMD+CUSDECU-IE++1++1'UNH+EDIFACT+CUSDEC:D:96B:UN:145050'BGM+ZEM:::EX+09SEE7JPUV5HC06IC6+Z'LOC+17+IT044100'LOC+18+SOL'LOC+35+SE'LOC+36+TZ'LOC+116+SE003033'DTM+9:20090527:102'DTM+268:20090626:102'DTM+182:20090527:102'";

        [HttpPost]
        public string[,] Get([FromBody]string ediData)
        {
            string[] ediNodes = ediData.Split("'");
            string[,] arrayWithLocs = new string[ediNodes.Where(x => x.Contains("LOC")).Count(), 2];

            int i = 0;
            foreach (var item in ediNodes)
            {
                string[] ediSegments = item.Split("+");
                if (ediSegments.FirstOrDefault().Equals("LOC"))
                {
                    arrayWithLocs[i, 0] = ediSegments[1];
                    if (ediSegments.Length >= 3)
                    {
                        arrayWithLocs[i, 1] = ediSegments[2];
                    }
                    i++;
                }
            }

            return arrayWithLocs;
        }
    }
}
