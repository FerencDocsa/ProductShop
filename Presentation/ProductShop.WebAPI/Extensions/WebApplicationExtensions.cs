using ProductShop.Persistence.DataContexts;

namespace ProductShop.WebAPI.Extensions
{
    /// <summary>
    /// Extensions for WebApplication
    /// </summary>
    public static class WebApplicationExtensions
    {
        /// <summary>
        /// Register swagger 
        /// </summary>
        /// <param name="app">WebApplication instance</param>
        public static void AddSwagger(this WebApplication app)
        {
            if (!app.Environment.IsDevelopment()) return;

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductShop API v1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "ProductShop API v2");
            });
        }

        /// <summary>
        /// Initialize database
        /// </summary>
        /// <param name="app">WebApplication instance</param>
        /// <param name="configuration">Configuration instance</param>
        public static void InitDatabase(this WebApplication app, IConfiguration configuration)
        {
            using var serviceScope = app.Services.GetService<IServiceScopeFactory>()?.CreateScope();
            var context = serviceScope?.ServiceProvider.GetService<ShopDbContext>();
            context?.Database.EnsureCreated();
        }
    }
}
