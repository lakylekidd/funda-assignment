using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FundaWebApplication.Services
{
    public class FundaService : IFundaService
    {
        private readonly HttpClient _client = new HttpClient();

        public async Task<IEnumerable<string>> Get()
        {
            throw new NotImplementedException();
        }
    }
}
