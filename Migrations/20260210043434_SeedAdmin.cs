using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPWebApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "RoleId" },
                values: new object[] { 3, "admin@gmail.com", "Super Admin", "AQAAAAEAACcQAAAAEEnE162OfCo1MXZom93FM/AfDyM7sFnruaIlJPcPuQPbapELOEaRpGl3rgU/KdxzQA==", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
