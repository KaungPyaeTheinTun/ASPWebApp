using ASPWebApp.Models;
using ASPWebApp.ViewModels;
using ASPWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ASPWebApp.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ASPWebApp.Controllers
{
    public class AuthController : BaseController<User>
    {
        public AuthController(IUserService userService, IBaseService<User> commonService)
            : base(userService, commonService) { }

        // --- LOGIN ---
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _userService.GetByEmail(model.Email);

            if (user == null || !_userService.VerifyPassword(user, model.Password))
            {
                SetTempData("Warning", "Invalid email or password.");
                return RedirectToAction("Login");
            }

            HttpContext.Session.SetString("UserName", user.Name);
            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetString("UserRole", user.RoleId.ToString());

            SetTempData("Success", "Welcome, " + user.Name);

            return user.RoleId == 1 
                ? RedirectToAction("Index", "Backend") 
                : RedirectToAction("Index", "Home");
        }

        // --- GOOGLE LOGIN ---
        public IActionResult GoogleLogin()
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleResponse", "Auth")
            };

            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var claims = result.Principal?.Identities.FirstOrDefault()?.Claims;

            var email = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var name = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            if (!string.IsNullOrEmpty(email))
            {
                HttpContext.Session.SetString("UserEmail", email);
                HttpContext.Session.SetString("UserName", name ?? "");
                SetTempData("Success", "Welcome, Google User, " + name);
            }

            return RedirectToAction("Index", "Home");
        }

        // --- REGISTER ---
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            if (!_userService.CreateUser(model.Name, model.Email, model.Password, 2, out string error))
            {
                SetTempData("Error", error);
                return View(model);
            }

            SetTempData("Success", "Registration successful!");
            return RedirectToAction("Login");
        }

        // --- LOGOUT ---
        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        // --- FORGOT PASSWORD ---
        public IActionResult ForgotPassword() => View();

        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = _userService.GetByEmail(model.Email);
            if (user == null)
            {
                SetTempData("Error", "Email not found.");
                return View(model);
            }

            var otp = new Random().Next(100000, 999999).ToString();
            HttpContext.Session.SetString("ForgotPasswordOTP", otp);
            HttpContext.Session.SetString("ForgotPasswordEmail", model.Email);
            HttpContext.Session.SetString("OTPExpiry", DateTime.UtcNow.AddMinutes(2).ToString());

            EmailHelper.SendOtpEmail(model.Email, otp);
            SetTempData("Success", "OTP sent to your email. It will expire in 2 minutes.");

            return RedirectToAction("VerifyOtp");
        }

        [HttpPost]
        public IActionResult ResendOtp()
        {
            var email = HttpContext.Session.GetString("ForgotPasswordEmail");
            if (string.IsNullOrEmpty(email))
            {
                SetTempData("Error", "Email not found. Please start forgot password again.");
                return RedirectToAction("ForgotPassword");
            }

            var user = _userService.GetByEmail(email);
            if (user == null)
            {
                SetTempData("Error", "User not found.");
                return RedirectToAction("ForgotPassword");
            }

            var otp = new Random().Next(100000, 999999).ToString();
            HttpContext.Session.SetString("ForgotPasswordOTP", otp);
            HttpContext.Session.SetString("OTPExpiry", DateTime.UtcNow.AddMinutes(2).ToString());

            EmailHelper.SendOtpEmail(email, otp);
            SetTempData("Success", "New OTP sent. It will expire in 2 minutes.");

            return RedirectToAction("VerifyOtp");
        }

        // --- VERIFY OTP ---
        public IActionResult VerifyOtp() => View(new VerifyOtpViewModel { OTP = "" });

        [HttpPost]
        public IActionResult VerifyOtp(VerifyOtpViewModel model)
        {
            if (!ModelState.IsValid)
            {
                SetTempData("Error", "Something went wrong!");
                return View(model);
            }

            var savedOtp = HttpContext.Session.GetString("ForgotPasswordOTP");
            var expiry = HttpContext.Session.GetString("OTPExpiry");

            if (savedOtp == null || expiry == null || DateTime.UtcNow > DateTime.Parse(expiry))
            {
                SetTempData("Error", "OTP expired. Please try again.");
                return RedirectToAction("ForgotPassword");
            }

            if (model.OTP != savedOtp)
            {
                SetTempData("Error", "Invalid OTP.");
                return View(model);
            }

            return RedirectToAction("ResetPassword");
        }

        // --- RESET PASSWORD ---
        public IActionResult ResetPassword() => View();

        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var email = HttpContext.Session.GetString("ForgotPasswordEmail");
            if (string.IsNullOrEmpty(email))
            {
                SetTempData("Warning", "Session expired. Please try again.");
                return RedirectToAction("ForgotPassword");
            }

            var user = _userService.GetByEmail(email);
            if (user == null)
            {
                SetTempData("Error", "User not found.");
                return RedirectToAction("ForgotPassword");
            }

            if (!PasswordHelper.IsValid(model.NewPassword, out string passwordError))
            {
                ModelState.AddModelError("", passwordError);
                return View(model);
            }

            user.Password = new PasswordHasher<User>().HashPassword(user, model.NewPassword);
            _userService.UpdatePassword(user.Id, user.Password);

            SetTempData("Success", "Password reset successfully!");
            return RedirectToAction("Login");
        }
    }
}