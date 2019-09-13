using System.Threading.Tasks;

namespace ABMData.Interfaces
{
    public interface EdiInterface
    {
        Task<string[,]> GetLocs(string body);
    }
}
