using Shell.DomainLayer.Gateways;
using Shell.DomainLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shell.DomainLayer.DomainManagers
{
    internal class WeatherManager : DomainManagerBase
    {
        WeatherGateway? _WeatherGateway;
        WeatherGateway TheWeatherGateway => _WeatherGateway ??= _serviceLocator.CreateWeatherGateway();


        public WeatherManager(ServiceLocator serviceLocator) : base(serviceLocator) {}

        public IEnumerable<WeatherForcastDTO> GetForcast()
        {
            return TheDataFacade.GetWeatherForcast("TX");
        }

        public async Task<string> GetWeatherAlertsAsync(string area)
        {
            return await TheWeatherGateway.GetWeatherAlertsAsync(area);
        }
    }
}
