using ASPWebApp.Models;
using ASPWebApp.Services.Interfaces;
using ASPWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ASPWebApp.Helpers;
using System.IO;

namespace ASPWebApp.Controllers
{
    public class AdminController : BaseController<User>
    {
        private readonly IMediaService _mediaService;

        public AdminController(IUserService userService, IMediaService mediaService)
            : base(userService)
        {
            _mediaService = mediaService;
        }

        [HttpGet]
        public IActionResult Profile()
        {
            var check = RequireAdmin();
            if (check != null) return check;

            var user = GetCurrentUser();
            if (user == null)
                return RedirectToAction("Login", "Auth");

            var model = new AdminProfileViewModel
            {
                Name = user.Name,
                Email = user.Email,
                CurrentImagePath = user.ProfileImage?.FilePath
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Profile(AdminProfileViewModel model)
        {
            var check = RequireAdmin();
            if (check != null) return check;

            var user = GetCurrentUser();
            if (user == null)
                return RedirectToAction("Login", "Auth");

            // Update Name and Email
            user.Name = model.Name;
            user.Email = model.Email;

            // Handle Profile Image Upload
            if (model.ProfileImageFile != null)
            {
                if (user.ProfileImage == null)
                {
                    user.ProfileImage = _mediaService.UploadFile(model.ProfileImageFile);
                }
                else
                {
                    user.ProfileImage = _mediaService.UpdateFile(
                        model.ProfileImageFile,
                        user.ProfileImage
                    );
                }
            }

            // Save changes via service
            if (!_userService.UpdateUser(user.Id, user.Name, user.Email, user.RoleId, out string error))
            {
                TempData["Error"] = error;
                model.CurrentImagePath = user.ProfileImage?.FilePath; // keep current image
                return View(model);
            }

            // Refresh session email if changed
            HttpContext.Session.SetString("UserEmail", model.Email);

            TempData["Success"] = "Profile updated successfully.";
            return RedirectToAction("Profile");
        }

        // POST: /Admin/ChangePassword
        [HttpPost]
        public IActionResult ChangePassword(AdminProfileViewModel model)
        {
            var check = RequireAdmin();
            if (check != null) return check;

            var user = GetCurrentUser();
            if (user == null)
                return RedirectToAction("Login", "Auth");

            // Protect against empty submission
            if (string.IsNullOrWhiteSpace(model.Password.CurrentPassword) ||
                string.IsNullOrWhiteSpace(model.Password.NewPassword) ||
                string.IsNullOrWhiteSpace(model.Password.ConfirmPassword))
            {
                TempData["Error"] = "All password fields are required.";
                return RedirectToAction("Profile");
            }

            var hasher = new PasswordHasher<User>();

            // Verify current password
            var result = hasher.VerifyHashedPassword(
                user,
                user.Password,
                model.Password.CurrentPassword
            );

            if (result == PasswordVerificationResult.Failed)
            {
                TempData["Error"] = "Current password is incorrect.";
                return RedirectToAction("Profile");
            }

            // Check confirm password
            if (model.Password.NewPassword != model.Password.ConfirmPassword)
            {
                TempData["Error"] = "Passwords do not match.";
                return RedirectToAction("Profile");
            }

            // Validate new password
            if (!PasswordHelper.IsValid(model.Password.NewPassword, out string validationError))
            {
                TempData["Error"] = validationError;
                return RedirectToAction("Profile");
            }

            // Hash new password and save
            user.Password = hasher.HashPassword(user, model.Password.NewPassword);
            _userService.UpdatePassword(user.Id, user.Password);

            TempData["Success"] = "Password changed successfully.";
            return RedirectToAction("Profile");
        }
    }
}