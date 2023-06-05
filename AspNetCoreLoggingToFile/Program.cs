using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Logging.ClearProviders();

var logger = new LoggerConfiguration()
    //.ReadFrom.Configuration(builder.Configuration)
    .WriteTo.File($"{builder.Configuration["LogPath"]}\\log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Logging.AddSerilog(logger);
builder.Logging.AddConsole();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
