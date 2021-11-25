using AspNetCoreAndMassTransitIntegrationTestExample.Api;
using AspNetCoreAndMassTransitIntegrationTestExample.Api.Consumers;
using MassTransit.Testing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace AspNetCoreAndMassTransitIntegrationTestExample.Tests
{
    public class ApiApplicationFactory
        : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("InMemoryTesting");

            builder.ConfigureServices(services =>
            {
                services.AddMassTransitInMemoryTestHarness(cfg =>
                {
                    cfg.AddConsumer<MessageConsumer>();
                });
            });
        }
    }
}
