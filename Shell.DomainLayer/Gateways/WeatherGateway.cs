using Shell.DomainLayer.Exceptions.GatewayExceptions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shell.DomainLayer.Gateways
{
    internal class WeatherGateway
    {
        static readonly Uri _baseUri = new Uri("https://api.weather.gov/alerts/active/");

        readonly ServiceLocator _serviceLocator;

        public WeatherGateway(ServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public async Task<string> GetWeatherAlertsAsync(string area)
        {
            var urlEncodedArea = Uri.EscapeDataString(area);
            var uri = new Uri(_baseUri, $"?area={urlEncodedArea}");
            var factory = _serviceLocator.CreateHttpClientFactory();

            using (var client = factory.CreateClient())
            {
                // client.Timeout = TimeSpan.FromMilliseconds(1); // default timeout is 100,000 ms
                client.DefaultRequestHeaders.Add("User-Agent", "ShivShell GitHub/matovich");
                try
                {
                    var response = await client.GetAsync(uri);

                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        return data.ToString();
                    }

                    throw new GetWeatherAlertsException(response.StatusCode, response.ReasonPhrase, area);
                }
                catch (TaskCanceledException)
                {
                    throw new GetWeatherAlertsException(System.Net.HttpStatusCode.RequestTimeout, "Third party timeout", area);
                }
            }
        }
    }
}
