using System.ComponentModel;

namespace ShopManagement_api.DTOs
{
    public class ApiDataRequestBaseDTO
    {
        [DefaultValue(1)]
        public int PageNumber { get; set; } = 1;
        [DefaultValue(10)]
        public int PageSize { get; set; } = 10;
    }
}
