using ProductShop.WebAPI.Extensions;

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
            app.MapControllers();
            app.Run();
        }
    }
}