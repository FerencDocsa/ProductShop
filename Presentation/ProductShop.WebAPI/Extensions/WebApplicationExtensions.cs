using ProductShop.Persistence.DataContexts;

namespace ProductShop.WebAPI.Extensions
{
    public static class WebApplicationExtensions
    {
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

        public static void InitDatabase(this WebApplication app, IConfiguration configuration)
        {
            using var serviceScope = app.Services.GetService<IServiceScopeFactory>()?.CreateScope();
            var context = serviceScope?.ServiceProvider.GetService<ShopDbContext>();
            context?.Database.EnsureCreated();
        }
    }
}
