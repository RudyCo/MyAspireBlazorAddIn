using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MyApp.Shared.Models;
using MyApp.Shared.Services;

namespace MyApp.AddIn.Client.Pages;

public partial class Weather : ComponentBase
{
    private WeatherForecast[]? forecasts;

    [Inject]
    public IWeatherService WeatherService { get; set; } = default!;

    [Inject]
    public IJSRuntime JSRuntime { get; set; } = default!;
    public IJSObjectReference JSModule { get; set; } = default!;

    public bool IsLoading
    {
        get
        {
            return forecasts is null;
        }
    }

    protected override async Task OnInitializedAsync()
    {
        await GetWeatherData();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            JSModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./Pages/Weather.razor.js");
        }
    }

    private async Task CopyButton()
    {
        if (forecasts is null) return;
        var res = forecasts.Select(x => new object[] { x.Date, x.TemperatureC, x.TemperatureF, x.Summary ?? "None" }).ToArray();
        await JSModule.InvokeVoidAsync("copyButton", (object)res);
    }

    private async Task RefreshButton()
    {
        await GetWeatherData();
    }

    private async Task GetWeatherData()
    {
        forecasts = null;
        forecasts = await WeatherService.GetWeatherAsync();
    }
}