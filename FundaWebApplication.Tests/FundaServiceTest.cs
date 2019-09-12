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
            // _fundaService = new FundaService();
        }

        //[Fact(DisplayName ="Get list of properties is not null")]
        //public async Task GetProperties()
        //{
        //    // Retrueve the properties
        //    var properties = await _fundaService.Get("koop", "/amsterdam/");
        //    Assert.NotNull(properties);
        //    Assert.True(properties.Count > 0);
        //}

        //[Fact(DisplayName = "Get list of agencies with properties")]
        //public async Task GetAgenciesWithProperties()
        //{
        //    // Retrueve the properties
        //    var agenciesWithProperties = await _fundaService.GetAgenciesWithMostPropertiesForSale("/amsterdam/");
        //    Assert.NotNull(agenciesWithProperties);
        //    Assert.True(agenciesWithProperties.Count > 0);
        //}
    }
}
