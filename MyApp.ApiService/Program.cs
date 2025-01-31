using MyApp.ApiService;
using MyApp.Shared.Services;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Register the server-side weather service
builder.Services.AddSingleton<IWeatherService, ServerWeatherService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

// Minimal API for obtaining weather data from /api/weather
app.MapGet("/api/weather", (IWeatherService weatherService) => weatherService.GetWeatherAsync());

app.MapDefaultEndpoints();

app.Run();