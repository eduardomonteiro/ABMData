using System.Linq;
using System.Threading.Tasks;
using ABMData.Interfaces;
using ABMData.Models;

namespace ABMData.Services
{
    public class EdiService : EdiInterface
    {
        public async Task<string[,]> GetLocs(string body)
        {

            string[] ediNodes = body.Split("'");
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
