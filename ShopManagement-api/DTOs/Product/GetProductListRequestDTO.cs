namespace ShopManagement_api.DTOs.Product
{
    public class GetProductListRequestDTO: ApiDataRequestBaseDTO
    {
        public string? ProductName { get; set; }
        public int? ProductType { get; set; }
        public decimal? MinimumPrice { get; set; }
        public decimal? MaximumPrice { get; set; }
        public int? ProductStatus { get; set; }

    }
}
