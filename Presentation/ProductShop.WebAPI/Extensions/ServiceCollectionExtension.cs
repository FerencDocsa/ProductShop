using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using ProductShop.Application.Extensions;
using ProductShop.Persistence.Extensions;
using ProductShop.WebAPI.Configuration;
using System.Reflection;

namespace ProductShop.WebAPI.Extensions
{
    /// <summary>
    /// Extension for registering dependencies
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Add needed services
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="configuration">Configuration</param>
        /// <returns>ServiceCollection</returns>
        public static IServiceCollection AddServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDatabaseContext(configuration);
            services.AddApplicationServices();
            services.AddRepositories();
            services.AddSwaggerGen(options =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
            services.ConfigureOptions<SwaggerConfiguration>();

            return services;
        }

        /// <summary>
        /// Add services for API versioning
        /// </summary>
        /// <param name="services">Services</param>
        /// <returns>ServiceCollection</returns>
        public static IServiceCollection AddApiVersioningConfiguration(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            });

            services.AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });


            return services;
        }
    }
}
