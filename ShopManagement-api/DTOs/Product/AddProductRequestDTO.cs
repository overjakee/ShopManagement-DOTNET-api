namespace ShopManagement_api.DTOs.Product
{
    public class AddProductRequestDTO
    {
        public string ProductName { get; set; }
        public int ProductType { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
    }
}
