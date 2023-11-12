using ProductShop.WebAPI.Extensions;
using ProductShop.WebAPI.Middlewares;
using Serilog;

namespace ProductShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure Serilog
            builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
                    .ReadFrom.Configuration(hostingContext.Configuration)
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day));

            // Add and configure services
            builder.Services.AddServices(builder.Configuration);
            builder.Services.AddApiVersioningConfiguration();
            builder.Services.AddControllers();
            
            var app = builder.Build();

            // Custom extensions
            app.AddSwagger();
            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

            app.UseSerilogRequestLogging();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}