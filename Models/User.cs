namespace ASPWebApp.Models
{
    public class User
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public string Password { get; set; } = "";

        public int RoleId { get; set; }

        public Role? Role { get; set; }

        public Media? ProfileImage { get; set; }
    }
}
