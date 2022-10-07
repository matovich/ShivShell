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

        [HttpGet("GetWeatherForcast", Name = nameof(GetForcast))]
        public ActionResult GetForcast()
        {
            var forcast = TheDomainFacade.GetWeatherForcast();
            return Ok(forcast.Select(f => new WeatherForcastDTO(f)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="area">Two-character state code.</param>
        /// <returns></returns>
        [HttpGet("GetWeatherAlerts{area}", Name = nameof(GetAlertsAsync))]
        public async Task<ActionResult> GetAlertsAsync(string area)
        {
            return Ok(await TheDomainFacade.GetWeatherAlertsAsync(area));
        }
    }
}