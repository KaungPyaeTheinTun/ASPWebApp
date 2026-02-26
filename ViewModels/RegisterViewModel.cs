using System.ComponentModel.DataAnnotations;

namespace ASPWebApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public required string Name { get; set; }

        [Required, EmailAddress]
        public required string Email { get; set; }

        [Required, MinLength(8)]
        public required string Password { get; set; }

        [Required, Compare("Password", ErrorMessage = "Passwords do not match")]
        public required string ConfirmPassword { get; set; }
    }
}
