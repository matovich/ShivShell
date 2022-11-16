using Shell.DomainLayer.DataLayer;
using Shell.DomainLayer.Gateways;
using System.Net.Http;

namespace Shell.DomainLayer
{
    internal class ProductionServiceLocator : ServiceLocator
    {
        readonly IHttpClientFactory _httpClientFactory;
        public ProductionServiceLocator(IHttpClientFactory httpClientFactory) : base()
        {
            _httpClientFactory = httpClientFactory;
        }

        protected override WeatherGateway CreateWeatherGatewayCore()
        {
            return new WeatherGateway(this);
        }

        protected override DataFacade CreateDataFacadeCore()
        {
            return new DataFacade();
        }

        protected override IHttpClientFactory CreateHttpClientFactoryCore()
        {
            return _httpClientFactory;
        }
    }
}
