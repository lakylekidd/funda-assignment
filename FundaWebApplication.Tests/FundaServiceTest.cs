using FundaWebApplication.Models;
using FundaWebApplication.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace FundaWebApplication.Tests
{
    public class FundaServiceTest
    {
        private readonly IFundaService _fundaService;

        public FundaServiceTest()
        {
            // Initialize the funda service instance
            _fundaService = new FundaService();
        }

        [Fact]
        public async Task Test1()
        {
            var res = await _fundaService.Get();
            Assert.NotNull(res);
        }
    }
}
