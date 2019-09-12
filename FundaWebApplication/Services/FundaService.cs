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

        public async Task<List<PropertyModel>> Get(string type, string location)
        {
            // Create a list that will hold a list of all properties in the query
            var properties = new List<PropertyModel>();

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
                    // Add all the properties in the list
                    properties.AddRange(result.Objects);
                    try
                    {
                        // Construct the next url query
                        url = generateUrlQueryString(type, location, i + 1);
                        // Retrieve the next page and get results as JSON
                        json = await hc.GetStringAsync(url);
                        // Convert the resulted JSON into a search result model
                        result = JsonConvert.DeserializeObject<SearchResultModel>(json);
                    }
                    catch(HttpRequestException)
                    {
                        // For now we are returning the properties we managed to retrieve
                        return properties;
                    }
                }
                // Return the retrieved properties
                return properties;
            }
        }

        public async Task<List<ResultByAgencyModel>> GetAgenciesWithMostPropertiesForSale(string location)
        {
            throw new NotImplementedException();
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
