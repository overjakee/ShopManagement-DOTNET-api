using System.ComponentModel.DataAnnotations;

namespace ShopManagement_api.Models
{
    public class ProductType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductTypeName { get; set; }

        // Navigation property
        public ICollection<Product> Products { get; set; }
    }
}
