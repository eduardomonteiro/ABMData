using System.Linq;
using System.Threading.Tasks;
using ABMData.Interfaces;
using ABMData.Models;

namespace ABMData.Services
{
    public class InputDocumentService : InputDocumentInterface
    {
        public async Task<string[,]> GetReferences(InputDocument xmlDoc)
        {
            var references = xmlDoc?.DeclarationList?.Declaration?.DeclarationHeader?.Reference.Where(x => x.RefCode.Equals("MWB") || x.RefCode.Equals("TRV") || x.RefCode.Equals("CAR"));
            string[,] RefTexts = new string[references.Count(), 2];

            if (references != null)
            {
                int i = 0;
                foreach (var item in references)
                {
                    RefTexts[i, 0] = item.RefCode;
                    if (item.RefText != null)
                    {
                        RefTexts[i, 1] = item.RefText;
                    }
                    i++;
                }
            }
            return RefTexts;
        }

        public async Task<string> ValidateStatus(InputDocument xmlDoc)
        {
                string message = "The document was structured correctly.";
                if (xmlDoc?.DeclarationList?.Declaration?.Command.ToLower() != "default")
                {
                    message = "Invalid command specified.";
                }
                else if (xmlDoc?.DeclarationList?.Declaration?.DeclarationHeader?.SiteID?.ToLower() != "dub")
                {
                    message = "Invalid Site specified.";
                }

                return message;
        }
    }
}
