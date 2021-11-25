using AspNetCoreAndMassTransitIntegrationTestExample.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace AspNetCoreAndMassTransitIntegrationTestExample.Tests
{
    public class ControllerTests
        : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public ControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/WeatherForecast");

            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
