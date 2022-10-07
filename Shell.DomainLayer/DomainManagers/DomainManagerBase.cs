using Shell.DomainLayer.DataLayer;

namespace Shell.DomainLayer.DomainManagers
{
    internal class DomainManagerBase
    {
        protected readonly ServiceLocator _serviceLocator;

        DataFacade? _dataFacade;
        protected DataFacade TheDataFacade => _dataFacade ??= _serviceLocator.CreateDataFacade();

        public DomainManagerBase(ServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }
    }
}
