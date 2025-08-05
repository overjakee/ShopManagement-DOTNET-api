using System.ComponentModel.DataAnnotations;

namespace ShopManagement_api.Models
{
    public class Role
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; } = null!;

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
