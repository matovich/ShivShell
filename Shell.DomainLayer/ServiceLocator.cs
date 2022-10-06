using Shell.DomainLayer.Gateways;
using System.Net.Http;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Shell.IntegrationTest")]

namespace Shell.DomainLayer
{
    abstract class ServiceLocator
    {
        public DataFacade CreateDataFacade() => CreateDataFacadeCore();

        public IHttpClientFactory CreateHttpClientFactory() => CreateHttpClientFactoryCore();

        public WeatherGateway CreateWeatherGateway() => CreateWeatherGatewayCore();

        protected abstract DataFacade CreateDataFacadeCore();
        protected abstract IHttpClientFactory CreateHttpClientFactoryCore();
        protected abstract WeatherGateway CreateWeatherGatewayCore();
    }
}
