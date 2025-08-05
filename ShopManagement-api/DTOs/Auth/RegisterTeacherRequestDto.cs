namespace ShopManagement_api.DTOs.Auth
{
    public class RegisterTeacherRequestDto : RegisterBaseRequestDto
    {
        public string TeachingPlace { get; set; } = null!;
    }
}
