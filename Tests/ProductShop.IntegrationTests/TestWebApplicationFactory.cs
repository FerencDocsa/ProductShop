using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using ProductShop.Persistence.Abstractions.DataContexts;
using ProductShop.Persistence.Abstractions.Repositories;
using ProductShop.Persistence.DataContexts;
using ProductShop.Persistence.Repositories;

namespace ProductShop.IntegrationTests
{
    public class TestWebApplicationFactory: WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                var shopDbDescriptor = services.SingleOrDefault(
                    c => c.ServiceType == typeof(DbContextOptions<ShopDbContext>));

                if (shopDbDescriptor != null) services.Remove(shopDbDescriptor);

                services.AddDbContext<IShopDbContext, ShopDbContext>(options =>
                {
                    options.UseInMemoryDatabase("ShopDBinMemory");
                });

                var productRepoDescriptor = services.SingleOrDefault(
                    c => c.ServiceType == typeof(IProductRepository));

                if (productRepoDescriptor != null) services.Remove(productRepoDescriptor);

                services.AddTransient<IProductRepository, ProductRepository>();
            });

            builder.UseEnvironment("Testing"); // Set the environment to "Test" or any other testing environment
        }
    }

}
