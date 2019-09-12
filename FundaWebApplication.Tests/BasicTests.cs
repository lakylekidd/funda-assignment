using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace FundaWebApplication.Tests
{
    public class BasicTests : IClassFixture<WebApplicationFactory<FundaWebApplication.Startup>>
    {
        protected readonly WebApplicationFactory<FundaWebApplication.Startup> _factory;

        public BasicTests(WebApplicationFactory<FundaWebApplication.Startup> factory)
        {
            _factory = factory;
        }

        [Theory(DisplayName ="Tests if all endpoints return html page")]
        [InlineData("/")]
        [InlineData("/Index")]
        [InlineData("/About")]
        [InlineData("/Privacy")]
        [InlineData("/Contact")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
