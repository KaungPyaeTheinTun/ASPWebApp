using Microsoft.EntityFrameworkCore;
using ASPWebApp.Models;
using Microsoft.AspNetCore.Identity;

namespace ASPWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Media> Media { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "User" }
            );

            var hasher = new PasswordHasher<User>();

            User admin = new User
            {
                Id = 1,
                Name = "Super Admin",
                Email = "admin@gmail.com",
                RoleId = 1,
                Password = "AQAAAAEAACcQAAAAEEnE162OfCo1MXZom93FM/AfDyM7sFnruaIlJPcPuQPbapELOEaRpGl3rgU/KdxzQA=="
            };

            modelBuilder.Entity<User>().HasData(admin);

            modelBuilder.Entity<User>()
            .HasOne(u => u.ProfileImage)
            .WithOne(m => m.User)
            .HasForeignKey<Media>(m => m.UserId);

        }
    }
}