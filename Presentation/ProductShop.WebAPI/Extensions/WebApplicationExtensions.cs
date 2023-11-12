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
    }
}
