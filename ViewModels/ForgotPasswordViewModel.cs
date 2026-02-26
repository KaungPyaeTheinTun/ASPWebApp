using System.ComponentModel.DataAnnotations;

namespace ASPWebApp.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
    }

}
