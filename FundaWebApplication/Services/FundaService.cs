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

        public FundaService()
        {
            
        }

        public async Task<string> Get()
        {
            using (HttpClient hc = new HttpClient())
            {
                var json = await hc.GetStringAsync("http://partnerapi.funda.nl/feeds/Aanbod.svc/json/ac1b0b1572524640a0ecc54de453ea9f/?type=koop&zo=/amsterdam/&pageSize=300");
                // Test deserializer
                var paging = JsonConvert.DeserializeObject<PagingModel>(json);

                return json;
            }
        }
    }
}
