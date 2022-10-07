using Shell.DomainLayer.DataLayer.DataManagers;
using Shell.DomainLayer.Models;
using System.Collections.Generic;

namespace Shell.DomainLayer.DataLayer
{
    internal sealed class DataFacade
    {
        public IEnumerable<WeatherForcastDTO> GetWeatherForcast()
            => WeatherDataManager.GetWeather();
    }
}
