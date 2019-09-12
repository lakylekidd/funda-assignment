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

        /// <summary>
        /// Async function that returns a list of the 10 top agencies that have
        /// the most properties available listed for sale
        /// </summary>
        /// <param name="type"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        Task<List<ResultByAgencyModel>> GetAgenciesWithMostPropertiesForSale(string location);
    }
}
