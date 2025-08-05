using ShopManagement_api.Interfaces.Repositories;
using ShopManagement_api.Interfaces.Services;

namespace ShopManagement_api.Services
{
    public class DashBoardService : IDashBoardService
    {
        private readonly IDashBoardRepository _dashBoardRepository;
        public DashBoardService(IDashBoardRepository dashBoardRepository)
        {
            _dashBoardRepository = dashBoardRepository;
        }

    }
}
