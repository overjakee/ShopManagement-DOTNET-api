namespace ShopManagement_api.DTOs.Product
{
    public class ProductDataResponeDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int ProductType { get; set; }
        public int StockQuantity { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int Status { get; set; } // 0 = Inactive, 1 = Active
    }
}
