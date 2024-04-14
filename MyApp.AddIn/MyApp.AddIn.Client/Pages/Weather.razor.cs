using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MyApp.AddIn.Client.Models;
using MyApp.AddIn.Client.Services;

namespace MyApp.AddIn.Client.Pages
{
    public partial class Weather : ComponentBase
    {

        [Inject]
        public PersistentComponentState PersistentComponentState { get; set; } = default!;


        [Inject]
        public IWeatherService WeatherService { get; set; } = default!;

        private WeatherForecast[]? forecasts;
        private PersistingComponentStateSubscription persistingSubscription;
        protected override async Task OnInitializedAsync()
        {
            persistingSubscription = PersistentComponentState.RegisterOnPersisting(PersistData);

            if (!PersistentComponentState.TryTakeFromJson<WeatherForecast[]>(nameof(forecasts), out forecasts))
            {
                forecasts = await WeatherService.GetWeather();
            }
        }
        private Task PersistData()
        {
            PersistentComponentState.PersistAsJson(nameof(forecasts), forecasts);

            return Task.CompletedTask;
        }


        [Inject]
        public IJSRuntime JSRuntime { get; set; } = default!;
        public IJSObjectReference JSModule { get; set; } = default!;

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
    }
}