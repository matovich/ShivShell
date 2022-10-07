using Microsoft.AspNetCore.Mvc;
using Shell.DomainLayer;

namespace Shell.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class BaseController : ControllerBase
    {
        private readonly DomainFacade domainFacade;

        public BaseController(DomainFacade domainFacade)
        {
            this.domainFacade = domainFacade;
        }

        protected DomainFacade TheDomainFacade => domainFacade;
    }
}
