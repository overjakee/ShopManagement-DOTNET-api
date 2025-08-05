using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopManagement_api.Datas;
using ShopManagement_api.DTOs.Auth;
using ShopManagement_api.Enums;
using ShopManagement_api.Interfaces.Repositories;
using ShopManagement_api.Models;

namespace ShopManagement_api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ShopManagementDbContext _context;
        public UserRepository(ShopManagementDbContext context) {
            _context = context;
        }
        public Task<bool> IsUsernameExistsAsync(string username)
        {
            return _context.Users.AnyAsync(u => u.Username == username);
        }

        public async Task<User?> LoginAsync(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (user == null)
                return null;

            var hasher = new PasswordHasher<User>();
            var result = hasher.VerifyHashedPassword(user, user.PasswordHash, password);

            if (result == PasswordVerificationResult.Failed)
                return null;

            return user;
        }

        public async Task<bool> RegisterGeneralAsync(RegisterGeneralRequestDto request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var hasher = new PasswordHasher<User>();
                var user = new User
                {
                    Username = request.Username,
                    Email = request.Email,
                    Title = request.Title,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Phone = request.PhoneNumber,
                    UserTypeId = (int)Enums.UserType.General,
                };
                user.PasswordHash = hasher.HashPassword(user, request.Password);

                var userResult = (await _context.Users.AddAsync(user)).Entity;
                await _context.SaveChangesAsync();

                await _context.GeneralProfiles.AddAsync(new GeneralProfile
                {
                    UserId = userResult.Id,
                    CitizenId = request.CitizenId
                });

                await _context.UserRoles.AddAsync(new UserRole
                {
                    UserId = userResult.Id,
                    RoleId = (int)RoleType.customer
                });

                await _context.SaveChangesAsync();

                // Commit transaction ถ้าทุกอย่างสำเร็จ
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                // Rollback transaction ถ้ามีข้อผิดพลาด
                await transaction.RollbackAsync();

                var innerMessage = ex.InnerException?.Message ?? "No inner exception";
                Console.WriteLine($"SaveChanges error: {ex.Message} / Inner: {innerMessage}");
                throw;
            }
        }
    }
}
