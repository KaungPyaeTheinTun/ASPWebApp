using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPWebApp.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserIdFromMediaAndAddMediaIdToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_Users_UserId",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_UserId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Media");

            migrationBuilder.AddColumn<int>(
                name: "MediaId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "MediaId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Users_MediaId",
                table: "Users",
                column: "MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Media_MediaId",
                table: "Users",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Media_MediaId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_MediaId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Media",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Media_UserId",
                table: "Media",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Users_UserId",
                table: "Media",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
