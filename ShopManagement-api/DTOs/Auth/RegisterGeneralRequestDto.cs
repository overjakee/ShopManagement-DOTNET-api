namespace ShopManagement_api.DTOs.Auth
{
    public class RegisterGeneralRequestDto : RegisterBaseRequestDto
    {
        public string CitizenId { get; set; } = null!;
    }
}
