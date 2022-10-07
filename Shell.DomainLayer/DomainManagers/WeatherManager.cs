using Shell.DomainLayer.DataLayer;
using Shell.DomainLayer.Gateways;
using Shell.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shell.DomainLayer.DomainManagers
{
    internal class WeatherManager
    {
        readonly ServiceLocator _serviceLocator;

        DataFacade? _dataFacade;
        DataFacade TheDataFacade => _dataFacade ??= _serviceLocator.CreateDataFacade();

        WeatherGateway? _WeatherGateway;
        WeatherGateway TheWeatherGateway => _WeatherGateway ??= _serviceLocator.CreateWeatherGateway();

        public WeatherManager(ServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public void GetForcast()
        {
            Task<string> wa = TheWeatherGateway.GetWeatherAlertsAsync("TX");
        }

        public WeatherForcastDTO GetAllBoardgames(AuthenticatedContext authContext)
        {
            return TheDataFacade.GetWeather("TX");
        }
    }
}
