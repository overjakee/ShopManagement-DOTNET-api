namespace ShopManagement_api.DTOs.Auth
{
    public class RegisterStudentRequestDto : RegisterBaseRequestDto
    {
        public string StudentId { get; set; } = null!;
        public string SchoolName { get; set; } = null!;
    }
}
