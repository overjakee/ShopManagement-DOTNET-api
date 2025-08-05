namespace ShopManagement_api.DTOs.Auth
{
    public class RegisterRequestDto
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Title { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int UserTypeId { get; set; }
    }
}
