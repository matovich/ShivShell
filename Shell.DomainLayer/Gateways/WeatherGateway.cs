using Shell.DomainLayer.Exceptions.GatewayExceptions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shell.DomainLayer.Gateways
{
    internal class WeatherGateway
    {
        static readonly Uri _baseUri = new Uri("https://api.weather.gov/alerts/active");

        readonly ServiceLocator _serviceLocator;

        public WeatherGateway(ServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public async Task<string> GetWeatherAlertsAsync(string area)
        {
            var urlEncodedArea = System.Uri.EscapeDataString(area);

            var uri = new System.Uri(_baseUri, $"?area={urlEncodedArea}");

            var factory = _serviceLocator.CreateHttpClientFactory();
            var client = factory.CreateClient();

            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return data;
            }

            throw new GetWeatherAlertsFailedException(response.StatusCode, response.ReasonPhrase ?? "(no reason)", area);
        }
    }
}
