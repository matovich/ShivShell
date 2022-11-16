using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Shell.Api.Models;
using Shell.DomainLayer;
using Shell.DomainLayer.Exceptions;
using Shell.DomainLayer.Exceptions.GatewayExceptions;

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

        [HttpGet("forecast", Name = nameof(GetForcast))]
        public IActionResult GetForcast()
        {
            var forcast = TheDomainFacade.GetWeatherForcast();
            return Ok(forcast.Select(f => new WeatherForcastDTO(f)));
        }

        /// <summary>
        /// Weather alerts by U.S. state.
        /// </summary>
        /// <param name="area">Two-character state code.</param>
        /// <returns></returns>
        [HttpGet("alerts/{area}", Name = nameof(GetAlertsAsync))]
        public async Task<IActionResult> GetAlertsAsync(string area)
        {
            try
            {
                var result = await TheDomainFacade.GetWeatherAlertsAsync(area);
                return Ok(result);
            }
            catch (HttpStatusException ex) {
                return GetErrorResponse(ex);
            }
        }
    }
}