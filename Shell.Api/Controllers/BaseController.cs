using Microsoft.AspNetCore.Mvc;
using Shell.DomainLayer;
using Shell.DomainLayer.Exceptions;
using Shell.DomainLayer.Exceptions.GatewayExceptions;

namespace Shell.Api.Controllers
{
    [ApiController]
    // [Route("[controller]")]  using this will automatically set the API to the class name of the controller but it you rename the class it will change your API 
    public abstract class BaseController : ControllerBase
    {
        private readonly DomainFacade domainFacade;

        public BaseController(DomainFacade domainFacade)
        {
            this.domainFacade = domainFacade;
        }

        protected DomainFacade TheDomainFacade => domainFacade;

        protected static IActionResult GetErrorResponse(HttpStatusException ex)
        {
            var error = new ProblemDetails
            {
                Type = $"https://httpstatuses.com/{(int)ex.StatusCode}",
                Title = "An error occurred",
                Detail = ex.Message,
                Status = (int)ex.StatusCode
            };

            return new ObjectResult(error) { StatusCode = (int)ex.StatusCode };
        }
    }
}
