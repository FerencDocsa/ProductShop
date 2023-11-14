using Microsoft.AspNetCore.Mvc.Testing;
using ProductShop.Persistence.Abstractions.Repositories;
using ProductShop.Persistence.DataContexts;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace ProductShop.IntegrationTests.Products
{
    public class ControllersTestBase : IClassFixture<TestWebApplicationFactory>
    {
        protected readonly ShopDbContext Context;
        protected readonly IProductRepository ProductRepository;
        public readonly HttpClient _client;

        public ControllersTestBase(TestWebApplicationFactory factory)
        {
            var scope = factory.Services.CreateScope();
            Context = scope.ServiceProvider.GetRequiredService<ShopDbContext>();
            ProductRepository = scope.ServiceProvider.GetRequiredService<IProductRepository>();
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions());
        }
    }
}
