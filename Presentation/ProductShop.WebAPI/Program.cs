using Microsoft.AspNetCore.Diagnostics;
using ProductShop.WebAPI.Extensions;
using ProductShop.WebAPI.Middlewares;

namespace ProductShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddServices(builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddApiVersioningConfiguration();
            
            var app = builder.Build();
            app.AddSwagger();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

            app.MapControllers();
            app.Run();
        }
    }
}