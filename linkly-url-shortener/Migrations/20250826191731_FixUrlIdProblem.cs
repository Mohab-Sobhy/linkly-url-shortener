using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace linkly_url_shortener.Migrations
{
    /// <inheritdoc />
    public partial class FixUrlIdProblem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Url_GuestUser_GuestId",
                table: "Url");

            migrationBuilder.DropForeignKey(
                name: "FK_Url_RegisterUser_UserId",
                table: "Url");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitLog_Url_UrlId1",
                table: "VisitLog");

            migrationBuilder.DropIndex(
                name: "IX_VisitLog_UrlId1",
                table: "VisitLog");

            migrationBuilder.DropIndex(
                name: "IX_Url_GuestId",
                table: "Url");

            migrationBuilder.DropIndex(
                name: "IX_Url_UserId",
                table: "Url");

            migrationBuilder.DropColumn(
                name: "UrlId1",
                table: "VisitLog");

            migrationBuilder.DropColumn(
                name: "GuestId",
                table: "Url");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UrlId1",
                table: "VisitLog",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GuestId",
                table: "Url",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VisitLog_UrlId1",
                table: "VisitLog",
                column: "UrlId1");

            migrationBuilder.CreateIndex(
                name: "IX_Url_GuestId",
                table: "Url",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Url_UserId",
                table: "Url",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Url_GuestUser_GuestId",
                table: "Url",
                column: "GuestId",
                principalTable: "GuestUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Url_RegisterUser_UserId",
                table: "Url",
                column: "UserId",
                principalTable: "RegisterUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitLog_Url_UrlId1",
                table: "VisitLog",
                column: "UrlId1",
                principalTable: "Url",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
