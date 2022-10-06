using System.Net.Http;

namespace Shell.DomainLayer
{
    class ProductionServiceLocator : ServiceLocator
    {
        readonly IHttpClientFactory _httpClientFactory;
        public ProductionServiceLocator(IHttpClientFactory httpClientFactory) : base()
        {
            _httpClientFactory = httpClientFactory;
        }

        protected override BoardgameGeekGateway CreateWeatherGatewayCore()
        {
            return new BoardgameGeekGateway(this);
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
