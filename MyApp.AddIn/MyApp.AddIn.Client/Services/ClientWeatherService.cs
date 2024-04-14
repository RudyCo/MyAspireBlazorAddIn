using MyApp.AddIn.Client.Models;
using System.Net.Http.Json;

namespace MyApp.AddIn.Client.Services
{
    public class ClientWeatherService(HttpClient httpClient) : IWeatherService
    {
        public Task<WeatherForecast[]> GetWeather() =>
            httpClient.GetFromJsonAsync<WeatherForecast[]>("/api/weather")!;
    }
}
