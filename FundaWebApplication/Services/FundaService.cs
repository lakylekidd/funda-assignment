using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<string>> Get()
        {
            throw new NotImplementedException();
        }
    }
}
