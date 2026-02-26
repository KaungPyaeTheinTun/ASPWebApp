using ASPWebApp.Models;
using ASPWebApp.Repositories.Interfaces;
using ASPWebApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ASPWebApp.Repositories.Implementations
{
    public class UserRepository : BaseRepository<User>, UserInterface
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public User? GetByEmail(string email)
            => _dbSet
                .Include(u => u.ProfileImage)
                .FirstOrDefault(u => u.Email == email);

        public List<User> GetByRoleId(int roleId)
            => _dbSet
                .Include(u => u.ProfileImage)
                .Where(u => u.RoleId == roleId)
                .ToList();
    }
}