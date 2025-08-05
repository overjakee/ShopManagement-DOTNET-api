using ShopManagement_api.DTOs;
using ShopManagement_api.DTOs.Product;
using ShopManagement_api.Models;

namespace ShopManagement_api.Interfaces.Services
{
    public interface IProductService
    {
        Task<ApiResponseDTO<object>> AddProductAsync(AddProductRequestDTO request);
        Task<ApiResponseDTO<PaginatedResult<ProductDataResponeDTO>>> GetAllProductsAsync(GetProductListRequestDTO request);
        Task<ApiResponseDTO<ProductDataResponeDTO>> GetProductByIdAsync(int productId);
        Task<ApiResponseDTO<object>> UpdateProductAsync(int productId, UpdateProductRequestDTO request);
        Task<ApiResponseDTO<object>> DeleteProductAsync(int productId);
    }
}
