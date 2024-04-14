using MyApp.AddIn.Client.Models;

namespace MyApp.AddIn.Client.Services
{
    public interface IWeatherService
    {
        Task<WeatherForecast[]> GetWeather();
    }

}
