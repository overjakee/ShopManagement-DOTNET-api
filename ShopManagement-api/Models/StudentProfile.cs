using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopManagement_api.Models
{
    public class StudentProfile
    {
        [Key]
        public int UserId { get; set; }

        [Required, MaxLength(20)]
        public string StudentCode { get; set; } = null!;

        [Required, MaxLength(100)]
        public string SchoolName { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;
    }
}
