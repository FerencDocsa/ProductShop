using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ProductShop.WebAPI.Configuration
{
    /// <summary>
    /// SwaggerConfiguration allows application to dynamically generate Swagger Docs for every available API version 
    /// </summary>
    public class SwaggerConfiguration : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public SwaggerConfiguration(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var apiVersionDescription in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(apiVersionDescription.GroupName, GenerateApiVersionInfo(apiVersionDescription));
            }
        }

        public void Configure(string? name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        private static OpenApiInfo GenerateApiVersionInfo(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Title = "ProductShop API",
                Version = description.ApiVersion.ToString()
            };
            
            return info;
        }
    }
}
