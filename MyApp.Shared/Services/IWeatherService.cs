using MyApp.Shared.Models;

namespace MyApp.Shared.Services
{
    public interface IWeatherService
    {
        public Task<WeatherForecast[]?> GetWeatherAsync();
    }
}