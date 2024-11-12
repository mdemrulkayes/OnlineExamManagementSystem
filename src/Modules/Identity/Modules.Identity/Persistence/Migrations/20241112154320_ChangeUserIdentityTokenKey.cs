using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modules.Identity.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserIdentityTokenKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTokens",
                schema: "Identity",
                table: "UserTokens");

            migrationBuilder.DropIndex(
                name: "IX_UserTokens_UserId",
                schema: "Identity",
                table: "UserTokens");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTokens",
                schema: "Identity",
                table: "UserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTokens",
                schema: "Identity",
                table: "UserTokens");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTokens",
                schema: "Identity",
                table: "UserTokens",
                columns: new[] { "LoginProvider", "UserId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_UserId",
                schema: "Identity",
                table: "UserTokens",
                column: "UserId");
        }
    }
}
