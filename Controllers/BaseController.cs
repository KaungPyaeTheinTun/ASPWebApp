using ASPWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ASPWebApp.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASPWebApp.Controllers
{
    public class BaseController<T> : Controller where T : class
    {
        protected readonly IUserService _userService;

        public BaseController(IUserService userService)
        {
            _userService = userService;
        }

        // --- ESSENTIAL SESSION/USER METHODS ---
        protected bool IsAdmin() => HttpContext.Session.GetString("UserRole") == "1";

        protected IActionResult? RequireAdmin()
        {
            if (!IsAdmin())
                return RedirectToAction("Index", "Home");
            return null;
        }

        protected User? GetCurrentUser()
        {
            var email = HttpContext.Session.GetString("UserEmail");
            return string.IsNullOrEmpty(email) ? null : _userService.GetByEmail(email);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var currentUser = GetCurrentUser();
            if (currentUser != null)
            {
                ViewData["Username"] = currentUser.Name;
                ViewData["Email"] = currentUser.Email;
                ViewData["ProfileImagePath"] = currentUser.ProfileImage?.FilePath ?? "/images/_.jpeg";
            }

            base.OnActionExecuting(context);
        }

        protected void SetTempData(string key, string message) => TempData[key] = message;

        // --- GENERIC CRUD METHODS ---
        // List all items
        protected IActionResult ListItems(Func<List<T>> getAllFunc)
        {
            var check = RequireAdmin();
            if (check != null) return check;

            var items = getAllFunc();
            return View(items);
        }

        // Show create page
        protected IActionResult CreateItemView()
        {
            var check = RequireAdmin();
            if (check != null) return check;
            return View();
        }

        // Handle create post
        protected IActionResult CreateItemPost(Func<bool> createFunc, string successMessage, string redirectAction = "Index")
        {
            var check = RequireAdmin();
            if (check != null) return check;

            if (!createFunc())
            {
                SetTempData("Error", "Unable to create item.");
                return View();
            }

            SetTempData("Success", successMessage);
            return RedirectToAction(redirectAction);
        }

        // Show edit page
        protected IActionResult EditItemView(Func<int, T?> getByIdFunc, int id)
        {
            var check = RequireAdmin();
            if (check != null) return check;

            var item = getByIdFunc(id);
            if (item == null) return NotFound();

            return View(item);
        }

        // Handle edit post
        protected IActionResult EditItemPost(Func<bool> updateFunc, T model, string successMessage, string redirectAction = "Index")
        {
            var check = RequireAdmin();
            if (check != null) return check;

            if (!updateFunc())
            {
                SetTempData("Error", "Unable to update item.");
                return View(model);
            }

            SetTempData("Success", successMessage);
            return RedirectToAction(redirectAction);
        }

        // Handle delete
        protected IActionResult DeleteItem(Func<int, (bool Success, string Error)> deleteFunc, int id)
        {
            var check = RequireAdmin();
            if (check != null) return check;

            var result = deleteFunc(id);
            if (!result.Success)
                SetTempData("Error", result.Error);
            else
                SetTempData("Success", "Deleted successfully.");

            var referer = Request.Headers["Referer"].ToString();
            return !string.IsNullOrEmpty(referer) ? Redirect(referer) : RedirectToAction("Index");
        }
    }
}