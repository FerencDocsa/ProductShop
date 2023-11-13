using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ProductShop.Persistence.Abstractions.Repositories;
using ProductShop.Persistence.DataContexts;
using ProductShop.Persistence.Repositories;
using ProductShop.Persistence.Abstractions.DataContexts;

namespace ProductShop.Persistence.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IShopDbContext, ShopDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnectionString"));
            });

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
