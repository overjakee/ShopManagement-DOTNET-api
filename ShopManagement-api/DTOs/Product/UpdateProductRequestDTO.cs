using ShopManagement_api.Enums;

namespace ShopManagement_api.DTOs.Product
{
    public class UpdateProductRequestDTO
    {
        public string ProductName { get; set; }
        public int ProductType { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ProductDescription { get; set; }
        public int StockQuantity { get; set; }
        public ProductStatus Status { get; set; }
    }
}
