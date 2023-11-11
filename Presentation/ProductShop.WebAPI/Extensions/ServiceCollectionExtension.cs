using ProductShop.Persistence.Extensions;

namespace ProductShop.WebAPI.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDatabaseContext(configuration);

            return services;
        }
    }
}
