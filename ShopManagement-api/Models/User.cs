using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopManagement_api.Models
{
    public class User
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Username { get; set; } = null!;

        [Required, MaxLength(255)]
        public string PasswordHash { get; set; } = null!;

        [Required, MaxLength(100)]
        public string Email { get; set; } = null!;

        [MaxLength(20)]
        public string? Phone { get; set; }

        [MaxLength(20)]
        public string? Title { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; } = null!;

        [Required, MaxLength(50)]
        public string LastName { get; set; } = null!;

        public int UserTypeId { get; set; }

        [ForeignKey(nameof(UserTypeId))]
        public UserType UserType { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<UserRole> UserRoles { get; set; }

        public GeneralProfile? GeneralProfile { get; set; }
        public StudentProfile? StudentProfile { get; set; }
        public TeacherProfile? TeacherProfile { get; set; }
    }
}
