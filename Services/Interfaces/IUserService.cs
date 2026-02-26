using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPWebApp.Models;

namespace ASPWebApp.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetAllByRoles(int? roleId = null);
        bool CreateUser(string name, string email, string password, int roleId, out string error);
        bool UpdateUser(int id, string name, string email, int roleId, out string error);
        bool DeleteUser(int id, string? currentUserName, out string error);
        User? GetByEmail(string email);
        User? GetById(int id);
        bool VerifyPassword(User user, string password);
        bool UpdatePassword(int userId, string hashedPassword);

    }
}
