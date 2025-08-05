using ShopManagement_api.Models;

namespace ShopManagement_api.Interfaces.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }

}
