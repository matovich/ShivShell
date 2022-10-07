using Microsoft.AspNetCore.Mvc;
using Shell.Api.Models;
using Shell.DomainLayer;

namespace Shell.Api.Controllers
{

    [Route("weather")]
    public class WeatherController : BaseController
    {
        private readonly ILogger<WeatherController> _logger;

        public WeatherController(ILogger<WeatherController> logger, DomainFacade domainFacade) : base(domainFacade)
        {
            _logger = logger;
        }

        [HttpGet("forcast", Name = nameof(GetForcast))]
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
        [HttpGet("alerts/{area}", Name = nameof(GetAlertsAsync))]
        public async Task<ActionResult> GetAlertsAsync(string area)
        {
            return Ok(await TheDomainFacade.GetWeatherAlertsAsync(area));
        }
    }
}