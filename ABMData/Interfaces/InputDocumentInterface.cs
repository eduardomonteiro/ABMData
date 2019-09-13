using System.Threading.Tasks;
using ABMData.Models;

namespace ABMData.Interfaces
{
    public interface InputDocumentInterface
    {
        Task<string[,]> GetReferences(InputDocument xmlDoc);

        Task<string> ValidateStatus(InputDocument xmlDoc);
    }
}
