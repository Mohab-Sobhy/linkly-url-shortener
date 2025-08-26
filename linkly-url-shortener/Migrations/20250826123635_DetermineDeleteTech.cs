using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace linkly_url_shortener.Migrations
{
    /// <inheritdoc />
    public partial class DetermineDeleteTech : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Url_GuestUser_GuestUserId",
                table: "Url");

            migrationBuilder.DropForeignKey(
                name: "FK_Url_RegisterUser_RegisterUserId",
                table: "Url");

            migrationBuilder.AddForeignKey(
                name: "FK_Url_GuestUser_GuestUserId",
                table: "Url",
                column: "GuestUserId",
                principalTable: "GuestUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Url_RegisterUser_RegisterUserId",
                table: "Url",
                column: "RegisterUserId",
                principalTable: "RegisterUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Url_GuestUser_GuestUserId",
                table: "Url");

            migrationBuilder.DropForeignKey(
                name: "FK_Url_RegisterUser_RegisterUserId",
                table: "Url");

            migrationBuilder.AddForeignKey(
                name: "FK_Url_GuestUser_GuestUserId",
                table: "Url",
                column: "GuestUserId",
                principalTable: "GuestUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Url_RegisterUser_RegisterUserId",
                table: "Url",
                column: "RegisterUserId",
                principalTable: "RegisterUser",
                principalColumn: "Id");
        }
    }
}
