using System.Threading.Tasks;

namespace FundaWebApplication.Services
{
    public interface IFundaService
    {
        Task<string> Get();
    }
}
