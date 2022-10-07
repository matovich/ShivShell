using Shell.DomainLayer.Gateways;
using Shell.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shell.DomainLayer.DomainManagers
{
    // RULE:  Managers do not talk to other managers
    internal class WeatherManager : DomainManagerBase
    {
        WeatherGateway? _WeatherGateway;
        WeatherGateway TheWeatherGateway => _WeatherGateway ??= _serviceLocator.CreateWeatherGateway();


        public WeatherManager(ServiceLocator serviceLocator) : base(serviceLocator) {}

        public IEnumerable<WeatherForcastDTO> GetForcast()
        {
            return TheDataFacade.GetWeatherForcast();
        }

        public async Task<string> GetWeatherAlertsAsync(string area)
        {
            var validArea = AreaValidator(area);
            return await TheWeatherGateway.GetWeatherAlertsAsync(validArea);
        }

        // RULE: Validation done in Managers
        private string AreaValidator(string area)
        {
            return area.Substring(0, 2);
        }
    }
}
