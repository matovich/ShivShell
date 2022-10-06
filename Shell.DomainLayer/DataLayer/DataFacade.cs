using Shell.DomainLayer.DataLayer.DataManagers;
using Shell.DomainLayer.Models;

namespace Shell.DomainLayer.DataLayer
{
    internal sealed class DataFacade
    {
        WeatherDataManager? _weatherDataManager;
        WeatherDataManager TheWeatherDataManager => _weatherDataManager ??= new WeatherDataManager();

        public WeatherForcastDTO GetWeather(string zone)
            => TheWeatherDataManager.Getweather(zone);
    }
}
