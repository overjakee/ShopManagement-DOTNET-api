using ShopManagement_api.DTOs;
using ShopManagement_api.DTOs.Product;
using ShopManagement_api.Interfaces.Repositories;
using ShopManagement_api.Interfaces.Services;
using ShopManagement_api.Models;

namespace ShopManagement_api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ApiResponseDTO<object>> AddProductAsync(AddProductRequestDTO request)
        {
            try
            {
                var result = await _productRepository.AddProductAsync(request);
                return ApiResponseDTO<object>.Success(message: "Product added successfully");
            }
            catch (Exception ex)
            {
                return ApiResponseDTO<object>.Failure(message: "Failed to add product", errors: new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponseDTO<PaginatedResult<ProductDataResponeDTO>>> GetAllProductsAsync(GetProductListRequestDTO request)
        {
            try
            {
                var result = await _productRepository.GetAllProductsAsync(request);

                var totalItems = result.Count; // (ถ้ามี logic นับทั้งหมดแยก จะใช้จากนั้นแทน)
                var items = result.Select(p => new ProductDataResponeDTO
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    ProductType = p.ProductTypeId,
                    StockQuantity = p.Total,
                    Description = p.ProductDetail,
                    ImageUrl = p.ProductImage,
                    Status = p.Status
                }).ToList();

                var paginated = new PaginatedResult<ProductDataResponeDTO>
                {
                    TotalItems = totalItems,
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    Items = items
                };

                return ApiResponseDTO<PaginatedResult<ProductDataResponeDTO>>.Success(paginated);
            }
            catch (Exception ex)
            {
                return ApiResponseDTO<PaginatedResult<ProductDataResponeDTO>>.Failure(message: "Failed to fetch product list", errors: new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponseDTO<ProductDataResponeDTO>> GetProductByIdAsync(int productId)
        {
            var result = await _productRepository.GetProductByIdAsync(productId);
            if (result == null)
            {
                return ApiResponseDTO<ProductDataResponeDTO>.Failure(message: "Product not found");
            }

            var product = new ProductDataResponeDTO
            {
                Id = result.Id,
                ProductName = result.ProductName,
                Price = result.Price,
                ProductType = result.ProductTypeId,
                StockQuantity = result.Total,
                Description = result.ProductDetail,
                ImageUrl = result.ProductImage,
                Status = result.Status
            };

            return ApiResponseDTO<ProductDataResponeDTO>.Success(product);
        }

        public async Task<ApiResponseDTO<object>> UpdateProductAsync(int productId, UpdateProductRequestDTO request)
        {
            try
            {
                await _productRepository.UpdateProductAsync(productId, request);
                return ApiResponseDTO<object>.Success(message: "Product updated successfully");
            }
            catch (Exception ex)
            {
                return ApiResponseDTO<object>.Failure(message: "Failed to update product", errors: new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponseDTO<object>> DeleteProductAsync(int productId)
        {
            try
            {
                var deleted = await _productRepository.DeleteProductAsync(productId);
                if (!deleted)
                    return ApiResponseDTO<object>.Failure(message: "Product not found or already inactive");

                return ApiResponseDTO<object>.Success(message: "Product deleted (set inactive) successfully");
            }
            catch (Exception ex)
            {
                return ApiResponseDTO<object>.Failure(message: "Failed to delete product", errors: new List<string> { ex.Message });
            }
        }
    }
}
