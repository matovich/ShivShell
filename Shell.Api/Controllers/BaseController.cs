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
        public BaseController(DomainFacade domainFacade)
        {
            TheDomainFacade = domainFacade;
        }

        protected DomainFacade TheDomainFacade { get; init; }
    }
}
