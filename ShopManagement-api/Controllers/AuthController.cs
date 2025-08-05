using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopManagement_api.DTOs.Auth;
using ShopManagement_api.Interfaces.Services;

namespace ShopManagement_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register-general")]
        public async Task<IActionResult> GeneralRegister(RegisterGeneralRequestDto request)
        {
            try
            {
                var result = await _authService.RegisterGeneralAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        //[HttpPost("register-student")]
        //public async Task<IActionResult> StudentRegister(RegisterStudentRequestDto request)
        //{
        //    try
        //    {
        //        var result = await _authService.RegisterStudentAsync(request);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { Message = ex.Message });
        //    }
        //}

        //[HttpPost("register-teacher")]
        //public async Task<IActionResult> TeacherRegister(RegisterTeacherRequestDto request)
        //{
        //    try
        //    {
        //        var result = await _authService.RegisterTeacherAsync(request);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { Message = ex.Message });
        //    }
        //}

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            var result = await _authService.LoginAsync(request);
            if (result == null)
                return Unauthorized(new { Message = "Invalid username or password" });

            return Ok(result);
        }
    }
}
