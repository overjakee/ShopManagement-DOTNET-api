using ShopManagement_api.DTOs;
using ShopManagement_api.DTOs.Auth;

namespace ShopManagement_api.Interfaces.Services
{
    public interface IAuthService
    {
        Task<ApiResponseDTO<object>> RegisterGeneralAsync(RegisterGeneralRequestDto request);
        Task<ApiResponseDTO<object>> RegisterStudentAsync(RegisterStudentRequestDto request);
        Task<ApiResponseDTO<object>> RegisterTeacherAsync(RegisterTeacherRequestDto request);
        Task<ApiResponseDTO<AuthResponseDto>> LoginAsync(LoginRequestDto request);
    }
}
