using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopManagement_api.Models
{
    public class TeacherProfile
    {
        [Key]
        public int UserId { get; set; }

        [Required, MaxLength(200)]
        public string TeachingPlace { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;
    }
}
