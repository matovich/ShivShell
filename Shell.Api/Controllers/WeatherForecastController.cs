using Microsoft.AspNetCore.Mvc;
using Shell.Api.Models;
using Shell.DomainLayer;

namespace Shell.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : BaseController
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, DomainFacade domainFacade) : base(domainFacade)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForcastDTO> Get()
        {
            var forcast = TheDomainFacade.GetWeatherForcast();
            return forcast.Select(f => new WeatherForcastDTO(f));
        }
    }
}