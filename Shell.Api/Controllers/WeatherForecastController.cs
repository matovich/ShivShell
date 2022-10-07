using Microsoft.AspNetCore.Mvc;
using Shell.DomainLayer;
using Shell.DomainLayer.Models;

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
            return TheDomainFacade.GetWeatherForcast();
        }
    }
}