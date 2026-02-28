using ASPWebApp.Models;
using ASPWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ASPWebApp.ViewModels;

namespace ASPWebApp.Controllers
{
    public class BackendController : BaseController<User>
    {
        public BackendController(IUserService userService, IBaseService<User> commonService)
            : base(userService, commonService) { }

        // --- DASHBOARD ---
        public IActionResult Index()
        {
            var currentUser = GetCurrentUser();
            if (currentUser == null)
                return RedirectToAction("Login", "Auth");

            ViewData["Username"] = currentUser.Name;
            ViewData["Email"] = currentUser.Email;

            return View("Dashboard");
        }

        // --- USERS LIST ---
        public IActionResult UserList()
        {
            var users = _userService.GetAllByRoles(2);
            return View("UserList", users);
        }

        // --- ADMINS LIST ---
        public IActionResult AdminList()
        {
            var admins = _userService.GetAllByRoles(1);
            return View("AdminList", admins);
        }

        // --- CREATE ADMIN ---
        public IActionResult CreateAdmin() => View();

        [HttpPost]
        public IActionResult CreateAdmin(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (!_userService.CreateUser(model.Name, model.Email, model.Password, 1, out string error))
            {
                TempData["Error"] = error;
                return View(model);
            }

            TempData["Success"] = "Admin created successfully.";
            return RedirectToAction("AdminList");
        }

        // --- EDIT ADMIN ---
        public IActionResult EditAdmin(int id)
        {
            var admin = _userService.GetById(id);
            if (admin == null)
                return NotFound();

            return View(admin);
        }

        [HttpPost]
        public IActionResult EditAdmin(User user)
        {
            if (!_userService.UpdateUser(user.Id, user.Name, user.Email, 1, out string error))
            {
                TempData["Error"] = error;
                return View(user);
            }

            TempData["Success"] = "Admin updated successfully.";
            return RedirectToAction("AdminList");
        }

        // --- DELETE ADMIN ---
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var currentUserName = HttpContext.Session.GetString("UserName");

            if (!_userService.DeleteUser(id, currentUserName, out string error))
            {
                TempData["Error"] = error;
            }
            else
            {
                TempData["Success"] = "Deleted successfully.";
            }

            return RedirectToAction("AdminList");
        }

        // --- HELPER ---
        private User? GetCurrentUser()
        {
            var email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(email))
                return null;

            return _userService.GetByEmail(email);
        }
    }
}