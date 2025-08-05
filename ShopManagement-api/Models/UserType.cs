using System.ComponentModel.DataAnnotations;

namespace ShopManagement_api.Models
{
    public class UserType
    {
        public UserType()
        {
            Users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string TypeName { get; set; } = null!;

        public ICollection<User> Users { get; set; }
    }
}
