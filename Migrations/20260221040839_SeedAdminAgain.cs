using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASPWebApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdminAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

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
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "RoleId" },
                values: new object[] { 1, "admin@gmail.com", "Super Admin", "AQAAAAEAACcQAAAAEEnE162OfCo1MXZom93FM/AfDyM7sFnruaIlJPcPuQPbapELOEaRpGl3rgU/KdxzQA==", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "RoleId" },
                values: new object[,]
                {
                    { 3, "admin@gmail.com", "Super Admin", "AQAAAAEAACcQAAAAEEnE162OfCo1MXZom93FM/AfDyM7sFnruaIlJPcPuQPbapELOEaRpGl3rgU/KdxzQA==", 1 },
                    { 4, "user1@gmail.com", "User 1", "AQAAAAIAAYagAAAAEJ+AWDdxL8AFYEWn7ZZWFITGkTzffI55U74QH2nn7rbJfnYMR9bQesyQkYCrLFbRgw==", 2 },
                    { 5, "user2@gmail.com", "User 2", "AQAAAAIAAYagAAAAENSeevxiOZmmSfM5Un/M6XTxGuPyuF7+ItLA1pTGEy/o5czgSee1832Q19aIhignWg==", 2 },
                    { 6, "user3@gmail.com", "User 3", "AQAAAAIAAYagAAAAEH1EyviE0aDWa0UbLIeJGlAFK2M1NvN4qGckrU8wiC/HrBiaFbJbb/9DJ//kMnBCFw==", 2 },
                    { 7, "user4@gmail.com", "User 4", "AQAAAAIAAYagAAAAEMapLh3B1bpBSaiI0hhxsmaH7Hq5TZMojoJ8KTXrUp63xTmt1LXqp3mKcvA1CqtDuA==", 2 },
                    { 8, "user5@gmail.com", "User 5", "AQAAAAIAAYagAAAAEDTmvDqI+a9T3jHd1+CzaRWOvF6Emdp9QqtGmLezP6yYWmuC8qg9xCeWHfwUEzB/1Q==", 2 },
                    { 9, "user6@gmail.com", "User 6", "AQAAAAIAAYagAAAAEPhb42gLaX7ul5vudIcg5VZ60jzfKyM0y9APNzyirHHskCLdouU7kvSAGy2BPI0Jlg==", 2 },
                    { 10, "user7@gmail.com", "User 7", "AQAAAAIAAYagAAAAEO7VT/PxsL+ZR34TkkbN6irS75Dn61dc3MTzn6wrS4te9+8PSTsiIAe0PH0+M6QHcw==", 2 },
                    { 11, "user8@gmail.com", "User 8", "AQAAAAIAAYagAAAAEGBzziwGgbObjvg1zOHFpdGMl+aWckIabQGrNgkEtFI65k5Bgvzcx6J39AFi3pP7Og==", 2 },
                    { 12, "user9@gmail.com", "User 9", "AQAAAAIAAYagAAAAEKWCCbVzwDOqE9lOOpFqSZRTYOKiapEEh/9BxtZowYDtUXSpJQ0HDIaQ7k4p+mjEBQ==", 2 },
                    { 13, "user10@gmail.com", "User 10", "AQAAAAIAAYagAAAAEN4uHuDTbZpPOjw8NFZ37Rtm5VG7/jPvuvC3VLZ8tiijgu1JyskvFb+7xSXSDJeWNg==", 2 },
                    { 14, "user11@gmail.com", "User 11", "AQAAAAIAAYagAAAAEMqfDkqH4+T/W55wAA9NpcMEHGg6pNiPpLnLFioYEEHyvSLqxP0+zmXvN2NAMd/v1g==", 2 },
                    { 15, "user12@gmail.com", "User 12", "AQAAAAIAAYagAAAAECVzapduQ0G+wmeAjMpS3+eHa0UrP6AszTL81o0eKGdXmcFMt7YyuE/c/gYZJZ9BEg==", 2 },
                    { 16, "user13@gmail.com", "User 13", "AQAAAAIAAYagAAAAELZAtjZKYnurMkAdOx+i1pigZkC0lRHteqp97XvhHyI/Za+VE2xHTyQTHC47PRmDMg==", 2 },
                    { 17, "user14@gmail.com", "User 14", "AQAAAAIAAYagAAAAEKlo6ZHI4qS1KjlAFp7Es4+QrtNslNwcveDS8xGDDahEeeWerFl1R2iZQKsiOY+QRw==", 2 },
                    { 18, "user15@gmail.com", "User 15", "AQAAAAIAAYagAAAAEI/AO8ypcbXecR88xZT1hLHximerRkjZodlKu5o2WkYIZoSnvOQKv2QK+dR16fQ6Xg==", 2 },
                    { 19, "user16@gmail.com", "User 16", "AQAAAAIAAYagAAAAEHU7SZdSA6ZUZTKbIPnCSVj6Rsf2znwbspQ2ouU/cs/9gYdfSbgdvmPgrvKXx3Og+A==", 2 },
                    { 20, "user17@gmail.com", "User 17", "AQAAAAIAAYagAAAAEExWC2j1OAC6+kFUPYsSJHfT+JTSsOd02RfjP5Dz9ZWfeygerLYgokuD8E9W65cNLw==", 2 },
                    { 21, "user18@gmail.com", "User 18", "AQAAAAIAAYagAAAAEGuO6k4oVGfjiwpLIGQlI+33OHY08Dv22pp0HcHokOSWTMmKlffd3pRt/mVCokLOow==", 2 },
                    { 22, "user19@gmail.com", "User 19", "AQAAAAIAAYagAAAAEF9UH7uL5kS8p0Z0KznFoLIWD2mjDzmKY1A5ByDtL+PlzLtUCf6Au8G4xp/DymhFOg==", 2 },
                    { 23, "user20@gmail.com", "User 20", "AQAAAAIAAYagAAAAEE/I93M07+nJLlrvj5lf3FKXDwAWnfDoUfcSe+BsbhUPeNGf9Vl721JkxUkfISSDuA==", 2 }
                });
        }
    }
}
