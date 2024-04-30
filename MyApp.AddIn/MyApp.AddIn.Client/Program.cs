using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;
using MyApp.Shared.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddFluentUIComponents();

// Preconfigure an HttpClient for web API calls
builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Register the client-side weather service
builder.Services.AddSingleton<IWeatherService, ClientWeatherService>();


await builder.Build().RunAsync();