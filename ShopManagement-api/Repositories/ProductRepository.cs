using Microsoft.EntityFrameworkCore;
using ShopManagement_api.Datas;
using ShopManagement_api.DTOs.Product;
using ShopManagement_api.Enums;
using ShopManagement_api.Interfaces.Repositories;
using ShopManagement_api.Models;

namespace ShopManagement_api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopManagementDbContext _context;
        public ProductRepository(ShopManagementDbContext context)
        {
            _context = context;
        }
        public async Task<Product> AddProductAsync(AddProductRequestDTO request)
        {
            var entity = new Product
            {
                ProductName = request.ProductName,
                ProductTypeId = request.ProductType,
                Price = request.Price,
                ProductImage = request.ImageUrl,
                ProductDetail = request.Description,
                Total = request.StockQuantity,
                Status = (int)ProductStatus.Active,
                CreateBy = "admin",
                CreateDate = DateTime.UtcNow,
                UpdateBy = "admin",
                UpdateDate = DateTime.UtcNow
            };

            _context.Products.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<List<Product>> GetAllProductsAsync(GetProductListRequestDTO request)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.ProductName))
            {
                query = query.Where(p => p.ProductName.Contains(request.ProductName));
            }

            if (request.ProductType.HasValue)
            {
                query = query.Where(p => p.ProductTypeId == request.ProductType.Value);
            }

            if (request.MinimumPrice.HasValue)
            {
                query = query.Where(p => p.Price >= request.MinimumPrice.Value);
            }

            if (request.MaximumPrice.HasValue)
            {
                query = query.Where(p => p.Price <= request.MaximumPrice.Value);
            }

            if (request.ProductStatus.HasValue)
            {
                query = query.Where(p => p.Status == request.ProductStatus.Value);
            }

            query = query.Skip((request.PageNumber - 1) * request.PageSize)
                         .Take(request.PageSize);

            return await query.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int productId)
        {
            var result = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
            return result;
        }
        public async Task<Product> UpdateProductAsync(int productId, UpdateProductRequestDTO request)
        {
            var result = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
            if (result == null)
                throw new Exception("Product not found");

            result.ProductName = request.ProductName;
            result.ProductTypeId = request.ProductType;
            result.Price = request.Price;
            result.ProductImage = request.ImageUrl;
            result.ProductDetail = request.ProductDescription;
            result.Total = request.StockQuantity;
            result.Status = (int)request.Status;

            result.UpdateDate = DateTime.UtcNow;
            result.UpdateBy = "admin";

            _context.Products.Update(result);
            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
            if (product == null)
                return false;

            if (product.Status == (int)ProductStatus.Inactive)
                return true;

            product.Status = (int)ProductStatus.Inactive;
            product.UpdateDate = DateTime.UtcNow;
            product.UpdateBy = "admin"; 

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
