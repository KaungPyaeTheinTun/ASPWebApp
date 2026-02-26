using System.ComponentModel.DataAnnotations;

namespace ASPWebApp.ViewModels
{
    public class VerifyOtpViewModel
    {
        [Required]
        [StringLength(6, MinimumLength = 6)]
        public required string OTP { get; set; }
    }

}
