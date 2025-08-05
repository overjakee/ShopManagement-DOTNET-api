using Microsoft.EntityFrameworkCore;
using ShopManagement_api.Models;
using System.Collections.Generic;

namespace ShopManagement_api.Datas
{
    public class ShopManagementDbContext : DbContext
    {
        public ShopManagementDbContext(DbContextOptions<ShopManagementDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<UserType> UserTypes { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<UserRole> UserRoles { get; set; } = null!;
        public DbSet<GeneralProfile> GeneralProfiles { get; set; } = null!;
        public DbSet<StudentProfile> StudentProfiles { get; set; } = null!;
        public DbSet<TeacherProfile> TeacherProfiles { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductType> ProductTypes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });  // กำหนด composite primary key

            // (ถ้ามีความสัมพันธ์เพิ่มเติม เช่น User-UserRole, Role-UserRole กำหนดด้วย)
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<Product>()
            .HasOne(p => p.ProductType)
            .WithMany(pt => pt.Products)
            .HasForeignKey(p => p.ProductTypeId);
        }
    }
}
