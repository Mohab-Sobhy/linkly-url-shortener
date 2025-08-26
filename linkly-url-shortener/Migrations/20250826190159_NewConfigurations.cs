using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace linkly_url_shortener.Migrations
{
    /// <inheritdoc />
    public partial class NewConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OS",
                table: "VisitLog",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IpAddress",
                table: "VisitLog",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "DeviceType",
                table: "VisitLog",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "VisitLog",
                type: "character varying(45)",
                maxLength: 45,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Browser",
                table: "VisitLog",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UrlId1",
                table: "VisitLog",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ShortCode",
                table: "Url",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "RegisterUserId",
                table: "Url",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GuestUserId",
                table: "Url",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GuestId",
                table: "Url",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
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

            migrationBuilder.CreateIndex(
                name: "IX_RegisterUser_Email",
                table: "RegisterUser",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegisterUser_Username",
                table: "RegisterUser",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GuestUser_SessionToken",
                table: "GuestUser",
                column: "SessionToken",
                unique: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_RegisterUser_Email",
                table: "RegisterUser");

            migrationBuilder.DropIndex(
                name: "IX_RegisterUser_Username",
                table: "RegisterUser");

            migrationBuilder.DropIndex(
                name: "IX_GuestUser_SessionToken",
                table: "GuestUser");

            migrationBuilder.DropColumn(
                name: "UrlId1",
                table: "VisitLog");

            migrationBuilder.DropColumn(
                name: "GuestId",
                table: "Url");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Url");

            migrationBuilder.AlterColumn<string>(
                name: "OS",
                table: "VisitLog",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "IpAddress",
                table: "VisitLog",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "DeviceType",
                table: "VisitLog",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "VisitLog",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(45)",
                oldMaxLength: 45);

            migrationBuilder.AlterColumn<string>(
                name: "Browser",
                table: "VisitLog",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ShortCode",
                table: "Url",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "RegisterUserId",
                table: "Url",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "GuestUserId",
                table: "Url",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
