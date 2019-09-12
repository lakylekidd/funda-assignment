using FundaWebApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FundaWebApplication.Services
{
    public interface IFundaService
    {
        Task<List<PropertyModel>> Get(string type, string location);
    }
}
