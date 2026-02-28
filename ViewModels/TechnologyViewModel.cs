using Microsoft.AspNetCore.Http;

namespace ASPWebApp.ViewModels
{
    public class TechnologyViewModel
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public required string Category { get; set; }

        public string? Url { get; set; }

        public IFormFile? ImageFile { get; set; }

        public string? ExistingImagePath { get; set; }
    }
}