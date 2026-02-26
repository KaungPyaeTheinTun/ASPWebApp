namespace ASPWebApp.ViewModels
{
    public class AdminProfileViewModel
    {
        public required string Name { get; set; }
        public required string Email { get; set; }

        // For displaying current image
        public string? CurrentImagePath { get; set; }

        // For file upload
        public IFormFile? ProfileImageFile { get; set; }

        // Password change info
        public ChangePasswordViewModel Password { get; set; } = new();
    }
}