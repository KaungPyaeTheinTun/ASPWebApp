using ASPWebApp.Models;
using ASPWebApp.Repositories.Interfaces;
using ASPWebApp.Services.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using ASPWebApp.Helpers;

namespace ASPWebApp.Services.Implementations
{
    public class UserService : CommonService<User>, IUserService
    {
        private readonly UserInterface _userRepo;
        private readonly PasswordHasher<User> _passwordHasher;

        public UserService(UserInterface userRepo) 
            : base(userRepo) // pass repo to CommonService
        {
            _userRepo = userRepo;
            _passwordHasher = new PasswordHasher<User>();
        }

        // --- User-specific methods ---
        public List<User> GetAllByRoles(int? roleId = null)
        {
            if (roleId.HasValue)
                return _userRepo.GetByRoleId(roleId.Value);
            return _userRepo.GetAll().ToList();
        }

        public bool CreateUser(string name, string email, string password, int roleId, out string error)
        {
            error = "";

            if (_userRepo.Any(u => u.Email == email))
            {
                error = "Email already exists.";
                return false;
            }

            if (!PasswordHelper.IsValid(password, out string passwordError))
            {
                error = passwordError;
                return false;
            }

            var user = new User
            {
                Name = name,
                Email = email,
                RoleId = roleId
            };

            user.Password = _passwordHasher.HashPassword(user, password);

            // Use generic Create from CommonService
            Create(user);
            return true;
        }

        public bool UpdateUser(int id, string name, string email, int roleId, out string error)
        {
            error = "";
            try
            {
                var user = GetById(id); // Generic method from CommonService
                if (user == null) { error = "User not found"; return false; }

                user.Name = name;
                user.Email = email;
                user.RoleId = roleId;

                // Generic Update from CommonService
                Update(user);
                return true;
            }
            catch (System.Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public bool UpdatePassword(int userId, string hashedPassword)
        {
            var user = GetById(userId);
            if (user == null) return false;

            user.Password = hashedPassword;
            Update(user); // Generic Update
            return true;
        }

        public bool DeleteUser(int id, string? currentUserName, out string error)
        {
            error = "";
            try
            {
                var user = GetById(id);
                if (user == null) { error = "User not found"; return false; }
                if (user.Name == currentUserName) { error = "You cannot delete yourself"; return false; }

                Delete(user); // Generic Delete
                return true;
            }
            catch (System.Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public User? GetByEmail(string email) => _userRepo.GetByEmail(email);

        public bool VerifyPassword(User user, string password)
        {
            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
            return result != PasswordVerificationResult.Failed;
        }
    }
}