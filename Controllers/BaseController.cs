using ASPWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASPWebApp.Controllers
{
    public class BaseController<T> : Controller where T : class
    {
        protected readonly IUserService _userService;
        protected readonly IBaseService<T> _service;

        public BaseController(
            IUserService userService,
            IBaseService<T> service)
        {
            _userService = userService;
            _service = service;
        }

        protected bool IsAdmin() =>
            HttpContext.Session.GetString("UserRole") == "1";

        protected IActionResult? RequireAdmin()
        {
            if (!IsAdmin())
                return RedirectToAction("Index", "Home");

            return null;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var email = HttpContext.Session.GetString("UserEmail");

            if (!string.IsNullOrEmpty(email))
            {
                var user = _userService.GetByEmail(email);

                if (user != null)
                {
                    ViewData["Username"] = user.Name;
                    ViewData["Email"] = user.Email;
                    ViewData["ProfileImagePath"] = user.ProfileImage?.FilePath ?? "/images/_.jpeg";
                }
            }

            base.OnActionExecuting(context);
        }

        protected void SetTempData(string key, string message)
        {
            TempData[key] = message;
        }

        protected IActionResult ListItems()
        {
            var check = RequireAdmin();
            if (check != null) return check;

            var items = _service.GetAll();
            return View(items);
        }

        protected IActionResult CreateItem(T entity)
        {
            var check = RequireAdmin();
            if (check != null) return check;

            _service.Create(entity);

            SetTempData("Success", "Created successfully");
            return RedirectToAction("Index");
        }

        protected IActionResult EditItem(T entity)
        {
            var check = RequireAdmin();
            if (check != null) return check;

            _service.Update(entity);

            SetTempData("Success", "Updated successfully");
            return RedirectToAction("Index");
        }

        protected IActionResult DeleteItem(int id)
        {
            var check = RequireAdmin();
            if (check != null) return check;

            var entity = _service.GetById(id);

            if (entity == null)
                return NotFound();

            _service.Delete(entity);

            SetTempData("Success", "Deleted successfully");

            return RedirectToAction("Index");
        }
    }
}