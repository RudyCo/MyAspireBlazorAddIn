using MyApp.AddIn;
using MyApp.AddIn.Client.Services;
using MyApp.AddIn.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

// Register the server-side weather service
builder.Services.AddSingleton<IWeatherService, ServerWeatherService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(MyApp.AddIn.Client._Imports).Assembly);

// Minimal API for obtaining weather data from /api/weather
app.MapGet("/api/weather", (IWeatherService weatherService) => weatherService.GetWeather());

app.Run();
