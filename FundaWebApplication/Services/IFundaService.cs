using FundaWebApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FundaWebApplication.Services
{
    public interface IFundaService
    {
        /// <summary>
        /// Async function that returns a list of properties with provided parameters
        /// </summary>
        /// <param name="type">The property type</param>
        /// <param name="location">The property location</param>
        /// <returns></returns>
        Task<List<PropertyModel>> Get(string type, string location);
    }
}
