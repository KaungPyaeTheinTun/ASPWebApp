using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddUrlToTechnology : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Technologies",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Technologies");
        }
    }
}
