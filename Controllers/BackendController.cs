using ASPWebApp.Models;
using ASPWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ASPWebApp.ViewModels;

namespace ASPWebApp.Controllers
{
    public class BackendController : BaseController<User>
    {
        public BackendController(IUserService userService) : base(userService) { }

        public IActionResult index()
        {
            var currentUser = GetCurrentUser();
            if (currentUser == null) return RedirectToAction("Login", "Auth");

            ViewData["Username"] = currentUser.Name;
            ViewData["Email"] = currentUser.Email;

            return View("Dashboard");
        }

        // --- USERS ---
        public IActionResult UserList()
            => ListItems(() => _userService.GetAllByRoles(2));

        public IActionResult AdminList()
            => ListItems(() => _userService.GetAllByRoles(1));

        public IActionResult CreateAdmin()
            => CreateItemView();

        [HttpPost]
        public IActionResult CreateAdmin(RegisterViewModel model)
            => CreateItemPost(
                () => _userService.CreateUser(model.Name, model.Email, model.Password, 1, out _),
                "Admin created successfully.",
                "AdminList"
            );

        public IActionResult EditAdmin(int id)
            => EditItemView(_userService.GetById, id);

        [HttpPost]
        public IActionResult EditAdmin(User user)
            => EditItemPost(
                () => _userService.UpdateUser(user.Id, user.Name, user.Email, 1, out _),
                user,
                "Admin updated successfully.",
                "AdminList"
            );

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var currentUser = HttpContext.Session.GetString("UserName");
            return DeleteItem(itemId =>
            {
                var success = _userService.DeleteUser(itemId, currentUser, out string error);
                return (success, error);
            }, id);
        }
    }
}