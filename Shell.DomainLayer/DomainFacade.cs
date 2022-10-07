using System;
using System.Net.Http;

namespace Shell.DomainLayer
{
    public sealed partial class DomainFacade
    {
        readonly ServiceLocator _serviceLocator;

        public DomainFacade(IHttpClientFactory httpClientFactory) : this(new ProductionServiceLocator(httpClientFactory)) { }

        internal DomainFacade(ServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }
    }
}
