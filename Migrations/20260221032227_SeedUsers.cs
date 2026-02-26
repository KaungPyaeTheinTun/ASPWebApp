using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASPWebApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Name", "RoleId" },
                values: new object[] { "user2@gmail.com", "User 2", 2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "RoleId" },
                values: new object[,]
                {
                    { 2, "user1@gmail.com", "User 1", "AQAAAAEAACcQAAAAEEnE162OfCo1MXZom93FM/AfDyM7sFnruaIlJPcPuQPbapELOEaRpGl3rgU/KdxzQA==", 2 },
                    { 4, "user3@gmail.com", "User 3", "AQAAAAEAACcQAAAAEEnE162OfCo1MXZom93FM/AfDyM7sFnruaIlJPcPuQPbapELOEaRpGl3rgU/KdxzQA==", 2 },
                    { 5, "user4@gmail.com", "User 4", "AQAAAAEAACcQAAAAEEnE162OfCo1MXZom93FM/AfDyM7sFnruaIlJPcPuQPbapELOEaRpGl3rgU/KdxzQA==", 2 },
                    { 6, "user5@gmail.com", "User 5", "AQAAAAEAACcQAAAAEEnE162OfCo1MXZom93FM/AfDyM7sFnruaIlJPcPuQPbapELOEaRpGl3rgU/KdxzQA==", 2 },
                    { 7, "user6@gmail.com", "User 6", "AQAAAAEAACcQAAAAEEnE162OfCo1MXZom93FM/AfDyM7sFnruaIlJPcPuQPbapELOEaRpGl3rgU/KdxzQA==", 2 },
                    { 8, "user7@gmail.com", "User 7", "AQAAAAEAACcQAAAAEEnE162OfCo1MXZom93FM/AfDyM7sFnruaIlJPcPuQPbapELOEaRpGl3rgU/KdxzQA==", 2 },
                    { 9, "user8@gmail.com", "User 8", "AQAAAAEAACcQAAAAEEnE162OfCo1MXZom93FM/AfDyM7sFnruaIlJPcPuQPbapELOEaRpGl3rgU/KdxzQA==", 2 },
                    { 10, "user9@gmail.com", "User 9", "AQAAAAEAACcQAAAAEEnE162OfCo1MXZom93FM/AfDyM7sFnruaIlJPcPuQPbapELOEaRpGl3rgU/KdxzQA==", 2 },
                    { 11, "user10@gmail.com", "User 10", "AQAAAAEAACcQAAAAEEnE162OfCo1MXZom93FM/AfDyM7sFnruaIlJPcPuQPbapELOEaRpGl3rgU/KdxzQA==", 2 },
                    { 12, "user11@gmail.com", "User 11", "AQAAAAEAACcQAAAAEEnE162OfCo1MXZom93FM/AfDyM7sFnruaIlJPcPuQPbapELOEaRpGl3rgU/KdxzQA==", 2 },
                    { 13, "user12@gmail.com", "User 12", "AQAAAAEAACcQAAAAEEnE162OfCo1MXZom93FM/AfDyM7sFnruaIlJPcPuQPbapELOEaRpGl3rgU/KdxzQA==", 2 },
                    { 14, "user13@gmail.com", "User 13", "AQAAAAEAACcQAAAAEEnE162OfCo1MXZom93FM/AfDyM7sFnruaIlJPcPuQPbapELOEaRpGl3rgU/KdxzQA==", 2 },
                    { 15, "user14@gmail.com", "User 14", "AQAAAAEAACcQAAAAEEnE162OfCo1MXZom93FM/AfDyM7sFnruaIlJPcPuQPbapELOEaRpGl3rgU/KdxzQA==", 2 },
                    { 16, "user15@gmail.com", "User 15", "AQAAAAEAACcQAAAAEEnE162OfCo1MXZom93FM/AfDyM7sFnruaIlJPcPuQPbapELOEaRpGl3rgU/KdxzQA==", 2 },
                    { 17, "user16@gmail.com", "User 16", "AQAAAAEAACcQAAAAEEnE162OfCo1MXZom93FM/AfDyM7sFnruaIlJPcPuQPbapELOEaRpGl3rgU/KdxzQA==", 2 },
                    { 18, "user17@gmail.com", "User 17", "AQAAAAEAACcQAAAAEEnE162OfCo1MXZom93FM/AfDyM7sFnruaIlJPcPuQPbapELOEaRpGl3rgU/KdxzQA==", 2 },
                    { 19, "user18@gmail.com", "User 18", "AQAAAAEAACcQAAAAEEnE162OfCo1MXZom93FM/AfDyM7sFnruaIlJPcPuQPbapELOEaRpGl3rgU/KdxzQA==", 2 },
                    { 20, "user19@gmail.com", "User 19", "AQAAAAEAACcQAAAAEEnE162OfCo1MXZom93FM/AfDyM7sFnruaIlJPcPuQPbapELOEaRpGl3rgU/KdxzQA==", 2 },
                    { 21, "user20@gmail.com", "User 20", "AQAAAAEAACcQAAAAEEnE162OfCo1MXZom93FM/AfDyM7sFnruaIlJPcPuQPbapELOEaRpGl3rgU/KdxzQA==", 2 },
                    { 100, "admin@gmail.com", "Super Admin", "AQAAAAEAACcQAAAAEEnE162OfCo1MXZom93FM/AfDyM7sFnruaIlJPcPuQPbapELOEaRpGl3rgU/KdxzQA==", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Name", "RoleId" },
                values: new object[] { "admin@gmail.com", "Super Admin", 1 });
        }
    }
}
