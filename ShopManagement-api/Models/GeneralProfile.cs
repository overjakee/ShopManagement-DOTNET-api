using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopManagement_api.Models
{
    public class GeneralProfile
    {
        [Key]
        public int UserId { get; set; }

        [Required, MaxLength(13)]
        public string CitizenId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;
    }
}
