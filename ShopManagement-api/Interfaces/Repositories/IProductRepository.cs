using ShopManagement_api.DTOs.Product;
using ShopManagement_api.Models;

namespace ShopManagement_api.Interfaces.Repositories
{
    public interface IProductRepository
    {
        // ดูรายการสินค้าทั้งหมดตาม filter
        Task<List<Product>> GetAllProductsAsync(GetProductListRequestDTO request);
        
        // ดูรายละเอียดสินค้าตามรหัสสินค้า
        Task<Product?> GetProductByIdAsync(int productId);
        
        // เพิ่มสินค้าใหม่ (admin)
        Task<Product> AddProductAsync(AddProductRequestDTO request);

        // แก้ไขข้อมูลสินค้า (admin)
        Task<Product> UpdateProductAsync(int productId, UpdateProductRequestDTO request);

        // ลบสินค้า (admin)
        Task<bool> DeleteProductAsync(int productId);
    }
}
