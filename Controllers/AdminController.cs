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
        public AdminController(IUserService userService) : base(userService) { }

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
            if (model.ProfileImageFile != null && model.ProfileImageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(model.ProfileImageFile.FileName)}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImageFile.CopyTo(stream);
                }

                if (user.ProfileImage == null)
                {
                    user.ProfileImage = new Media
                    {
                        FileName = fileName,
                        FilePath = $"/uploads/{fileName}",
                        ContentType = model.ProfileImageFile.ContentType,
                        UserId = user.Id,
                        CreatedAt = DateTime.UtcNow
                    };
                }
                else
                {
                    // Optional: delete old file
                    var oldFile = Path.Combine(uploadsFolder, user.ProfileImage.FileName);
                    if (System.IO.File.Exists(oldFile))
                        System.IO.File.Delete(oldFile);

                    user.ProfileImage.FileName = fileName;
                    user.ProfileImage.FilePath = $"/uploads/{fileName}";
                    user.ProfileImage.ContentType = model.ProfileImageFile.ContentType;
                    user.ProfileImage.CreatedAt = DateTime.UtcNow;
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