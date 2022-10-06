using Shell.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shell.DomainLayer.DomainManagers
{
    internal class WeatherManager
    {
        readonly ServiceLocator _serviceLocator;

        DataFacade? _dataFacade;
        DataFacade TheDataFacade => _dataFacade ??= _serviceLocator.CreateDataFacade();

        WeatherGateway? _WeatherGateway;
        WeatherGateway TheWeatherGateway => _WeatherGateway ??= _serviceLocator.CreateWeatherGateway();

        public WeatherManager(ServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public async Task<BoardgameForGet> CreateNewBoardgameAsync(BoardgameForCreate boardgameForCreate, AuthenticatedContext authContext)
        {
            var response = await TheBoardgameGeekGateway.SearchForGameAsync(boardgameForCreate.Name);

            var createdBoardgame = TheDataFacade.CreateBoardgame(boardgameForCreate);

            return createdBoardgame;
        }

        public IReadOnlyList<BoardgameForGet> GetAllBoardgames(AuthenticatedContext authContext)
        {
            var allBoardgames = TheDataFacade.GetAllBoardgames();

            return allBoardgames;
        }
    }
}
