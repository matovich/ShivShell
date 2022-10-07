using Shell.DomainLayer.DomainManagers;
using Shell.DomainLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shell.DomainLayer
{
    public sealed partial class DomainFacade
    {
        WeatherManager? _weatherManager;
        WeatherManager TheWeatherManager { get { return _weatherManager ??= new WeatherManager(_serviceLocator); } }

        public IEnumerable<WeatherForcastDTO> GetWeatherForcast()
        {
            return TheWeatherManager.GetForcast();
        }

        public async Task<string> GetWeatherAlertsAsync(string area)
        {
            return await TheWeatherManager.GetWeatherAlertsAsync(area);
        }
    }
}
