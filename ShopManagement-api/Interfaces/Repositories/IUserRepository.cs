using ShopManagement_api.DTOs.Auth;
using ShopManagement_api.Models;

namespace ShopManagement_api.Interfaces.Repositories
{
    public interface IUserRepository
    {
        // ตรวจสอบว่า Username Password ถูกต้องหรือไม่
        Task<User> LoginAsync(string username, string password);
        // บันทึกข้อมูลผู้ใช้ทั่วไป
        Task<bool> RegisterGeneralAsync(RegisterGeneralRequestDto request);
        // ตรวจสอบว่ามีผู้ใช้ด้วย Username นี้หรือไม่
        Task<bool> IsUsernameExistsAsync(string username);
    }
}
