using ASPWebApp.Models;
using ASPWebApp.Repositories.Interfaces;
using ASPWebApp.Services.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using ASPWebApp.Helpers;

namespace ASPWebApp.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserInterface _userRepo;
        private readonly PasswordHasher<User> _passwordHasher;

        public UserService(UserInterface userRepo)
        {
            _userRepo = userRepo;
            _passwordHasher = new PasswordHasher<User>();
        }

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

            _userRepo.Create(user);
            return true;
        }

        public bool UpdateUser(int id, string name, string email, int roleId, out string error)
        {
            error = "";
            try
            {
                var user = _userRepo.GetById(id);
                if (user == null) { error = "User not found"; return false; }

                user.Name = name;
                user.Email = email;
                user.RoleId = roleId;
                _userRepo.Update(user);
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
            var user = _userRepo.GetById(userId);
            if (user == null) return false;

            user.Password = hashedPassword;
            _userRepo.Update(user);   // use repository update
            return true;
        }

        public bool DeleteUser(int id, string? currentUserName, out string error)
        {
            error = "";
            try
            {
                var user = _userRepo.GetById(id);
                if (user == null) { error = "User not found"; return false; }
                if (user.Name == currentUserName) { error = "You cannot delete yourself"; return false; }

                _userRepo.Delete(user);
                return true;
            }
            catch (System.Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public User? GetByEmail(string email) => _userRepo.GetByEmail(email);

        public User? GetById(int id) => _userRepo.GetById(id);

        public bool VerifyPassword(User user, string password)
        {
            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
            return result != PasswordVerificationResult.Failed;
        }
    }
}