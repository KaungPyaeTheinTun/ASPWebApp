using ASPWebApp.Models;
using System.Collections.Generic;

namespace ASPWebApp.Repositories.Interfaces
{
    public interface UserInterface : IBaseRepository<User>
    {
        User? GetByEmail(string email);
        List<User> GetByRoleId(int roleId);
    }
}