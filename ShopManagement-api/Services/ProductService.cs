using ShopManagement_api.Interfaces.Repositories;
using ShopManagement_api.Interfaces.Services;

namespace ShopManagement_api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
    }
}
