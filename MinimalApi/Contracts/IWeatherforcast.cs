using MinimalApi.Model;

namespace MinimalApi.Contracts
{
    public interface IWeatherforcastRepository
    {
        WeatherForecast[] GetWeatherForecasts();
    }
}
