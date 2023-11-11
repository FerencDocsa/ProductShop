using ProductShop.Application.Extensions;
using ProductShop.Persistence.Extensions;

namespace ProductShop.WebAPI.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDatabaseContext(configuration);
            services.AddApplicationServices();
            return services;
        }
    }
}
