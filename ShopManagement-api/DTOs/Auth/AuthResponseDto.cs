namespace ShopManagement_api.DTOs.Auth
{
    public class AuthResponseDto
    {
        //public int UserId { get; set; }
        //public string Username { get; set; } = null!;
        public string Token { get; set; } = null!; // ถ้ามี JWT
        //public string Message { get; set; } = null!;
    }
}
