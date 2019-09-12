using FundaWebApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace FundaWebApplication.Services
{
    public class FundaService : IFundaService
    {
        private readonly string _baseurl = "http://partnerapi.funda.nl/feeds/Aanbod.svc/json/";
        private readonly string _key = "ac1b0b1572524640a0ecc54de453ea9f";
        private readonly int _pageSize = 25;

        public FundaService()
        {

        }

        public async Task<SearchResultModel> Get(string type, string location)
        {
            // Construct the query string by calling the first page
            var url = generateUrlQueryString(type, location);

            // Initialize the http client
            using (HttpClient hc = new HttpClient())
            {
                // Retrieve the initial page and get results as JSON
                var json = await hc.GetStringAsync(url);
                // Convert the resulted JSON into a search result model
                var result = JsonConvert.DeserializeObject<SearchResultModel>(json);
                // Loop through pages and call remaining results
                for (int i = 1; i <= result.Paging.AantalPaginas; i++)
                {

                }

                return result;
            }
        }

        /// <summary>
        /// Private function that constructs a url with a query string based on provided type and location
        /// </summary>
        /// <param name="type">The type of the listing</param>
        /// <param name="location">The location of the listing</param>
        /// <param name="page">The current page to call</param>
        /// <returns></returns>
        private string generateUrlQueryString(string type, string location, int page = 1)
        {
            // Construct the query string
            var query = $"?type={type}&zo={location}&pageSize={_pageSize}&page={page}";
            // Create the url query string
            var url = $"{_baseurl}{_key}/{query}";
            // Return the constructed url
            return url;
        }
    }
}
