using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopManagement_api.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string ProductName { get; set; }

        [MaxLength(500)]
        public string ProductImage { get; set; }

        [ForeignKey("ProductType")]
        public int ProductTypeId { get; set; }

        public ProductType ProductType { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(10)]
        public int Status { get; set; } // Active / Inactive

        public string ProductDetail { get; set; }

        public int Total { get; set; }

        [MaxLength(100)]
        public string CreateBy { get; set; }

        public DateTime CreateDate { get; set; }

        [MaxLength(100)]
        public string UpdateBy { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
