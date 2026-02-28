namespace ASPWebApp.Models
{
    public class Technology
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public required string Category { get; set; }

        public string? Url { get; set; }

        public int? MediaId { get; set; }
        public Media? Media { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}