using FundaWebApplication.Models;
using System.Threading.Tasks;

namespace FundaWebApplication.Services
{
    public interface IFundaService
    {
        Task<SearchResultModel> Get(string type, string location);
    }
}
