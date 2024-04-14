using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MyApp.AddIn.Client.Pages
{
    public partial class Weather : ComponentBase
    {
        private WeatherForecast[]? forecasts;

        protected override async Task OnInitializedAsync()
        {
            // Simulate asynchronous loading to demonstrate a loading indicator
            await Task.Delay(500);

            var startDate = DateOnly.FromDateTime(DateTime.Now);
            var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
            forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries[Random.Shared.Next(summaries.Length)]
            }).ToArray();
        }

        private class WeatherForecast
        {
            public DateOnly Date { get; set; }
            public int TemperatureC { get; set; }
            public string? Summary { get; set; }
            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
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
            var res = forecasts.Select(x => new object[] { x.Date, x.TemperatureC, x.TemperatureF, x.Summary??"None" }).ToArray();
            await JSModule.InvokeVoidAsync("copyButton", (object)res);
        }
    }
}