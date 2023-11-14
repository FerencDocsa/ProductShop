using ProductShop.WebAPI.Extensions;
using ProductShop.WebAPI.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
        .ReadFrom.Configuration(hostingContext.Configuration)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day));

 builder.Services.AddServices(builder.Configuration);

builder.Services.AddApiVersioningConfiguration();
builder.Services.AddControllers();

var app = builder.Build();

// Custom extensions
app.AddSwagger();
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.UseSerilogRequestLogging();
app.InitDatabase(builder.Configuration);
app.UseAuthorization();
app.MapControllers();
app.Run();

/// <summary>
/// Workaround for integration testing
/// </summary>
public partial class Program { }