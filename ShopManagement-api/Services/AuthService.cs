using ShopManagement_api.DTOs;
using ShopManagement_api.DTOs.Auth;
using ShopManagement_api.Interfaces.Repositories;
using ShopManagement_api.Interfaces.Services;
using ShopManagement_api.Models;

namespace ShopManagement_api.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _authRepository;
        private readonly IJwtService _jwtService;
        public AuthService(IUserRepository authRepository, IJwtService jwtService)
        {
            _authRepository = authRepository;
            _jwtService = jwtService;
        }

        public async Task<ApiResponseDTO<AuthResponseDto>> LoginAsync(LoginRequestDto request)
        {
            var user = await _authRepository.LoginAsync(request.Username, request.Password);
            if (user == null)
            {
                return new ApiResponseDTO<AuthResponseDto>
                {
                    IsSuccess = false,
                    Message = "ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง"
                };
            }

            var token = _jwtService.GenerateToken(user);

            return new ApiResponseDTO<AuthResponseDto>
            {
                IsSuccess = true,
                Message = "เข้าสู่ระบบสำเร็จ",
                Data = new AuthResponseDto
                {
                    Token = token
                }
            };
        }


        public async Task<ApiResponseDTO<object>> RegisterGeneralAsync(RegisterGeneralRequestDto request)
        {
            var response = new ApiResponseDTO<object>();

            //bool isUsernameExists = await _authRepository.IsUsernameExistsAsync(request.Username);
            //if (isUsernameExists)
            //{
            //    response = new ApiResponseDTO<string>
            //    {
            //        Success = false,
            //        Message = "Username นี้ถูกใช้ไปแล้ว"
            //    };

            //    return response;
            //}

            bool isRegistered = await _authRepository.RegisterGeneralAsync(request);
            if (!isRegistered)
            {
                response = new ApiResponseDTO<object>
                {
                    IsSuccess  = false,
                    Message = "สมัครสมาชิกไม่สำเร็จ"
                };

                return response;
            }

            response = new ApiResponseDTO<object>
            {
                IsSuccess  = true,
                Message = "สมัครสมาชิกสำเร็จ"
            };

            return response;
        }

        public async Task<ApiResponseDTO<object>> RegisterStudentAsync(RegisterStudentRequestDto request)
        {
            var response = new ApiResponseDTO<object>
            {
                IsSuccess  = false,
                Message = "This method is not implemented yet."
            };

            return response;
        }

        public async Task<ApiResponseDTO<object>> RegisterTeacherAsync(RegisterTeacherRequestDto request)
        {
            var response = new ApiResponseDTO<object>
            {
                IsSuccess  = false,
                Message = "This method is not implemented yet."
            };

            return response;
        }
    }
}
