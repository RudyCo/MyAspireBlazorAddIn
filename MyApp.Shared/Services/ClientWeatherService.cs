using MyApp.Shared.Models;
using System.Net.Http.Json;

namespace MyApp.Shared.Services
{
    public class ClientWeatherService(HttpClient httpClient) : IWeatherService
    {
        public async Task<WeatherForecast[]?> GetWeatherAsync()
        {
            return await httpClient.GetFromJsonAsync<WeatherForecast[]?>("/api/weather");
        }
    }
}