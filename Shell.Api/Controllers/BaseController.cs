using Microsoft.AspNetCore.Mvc;
using Shell.DomainLayer;

namespace Shell.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly DomainFacade domainFacade;

        public BaseController(DomainFacade domainFacade)
        {
            this.domainFacade = domainFacade;
        }

        protected DomainFacade TheDomainFacade => domainFacade;
    }
}
