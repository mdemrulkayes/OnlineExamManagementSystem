using Microsoft.EntityFrameworkCore.Migrations;

namespace api.oems.Migrations
{
    public partial class Add_Package_Table_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TutorInPackage_Package_PackageId",
                table: "TutorInPackage");

            migrationBuilder.DropForeignKey(
                name: "FK_TutorInPackage_User_UserId",
                table: "TutorInPackage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TutorInPackage",
                table: "TutorInPackage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Package",
                table: "Package");

            migrationBuilder.RenameTable(
                name: "TutorInPackage",
                newName: "TutorInPackages");

            migrationBuilder.RenameTable(
                name: "Package",
                newName: "Packages");

            migrationBuilder.RenameIndex(
                name: "IX_TutorInPackage_UserId",
                table: "TutorInPackages",
                newName: "IX_TutorInPackages_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TutorInPackage_PackageId",
                table: "TutorInPackages",
                newName: "IX_TutorInPackages_PackageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TutorInPackages",
                table: "TutorInPackages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Packages",
                table: "Packages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TutorInPackages_Packages_PackageId",
                table: "TutorInPackages",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TutorInPackages_User_UserId",
                table: "TutorInPackages",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TutorInPackages_Packages_PackageId",
                table: "TutorInPackages");

            migrationBuilder.DropForeignKey(
                name: "FK_TutorInPackages_User_UserId",
                table: "TutorInPackages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TutorInPackages",
                table: "TutorInPackages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Packages",
                table: "Packages");

            migrationBuilder.RenameTable(
                name: "TutorInPackages",
                newName: "TutorInPackage");

            migrationBuilder.RenameTable(
                name: "Packages",
                newName: "Package");

            migrationBuilder.RenameIndex(
                name: "IX_TutorInPackages_UserId",
                table: "TutorInPackage",
                newName: "IX_TutorInPackage_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TutorInPackages_PackageId",
                table: "TutorInPackage",
                newName: "IX_TutorInPackage_PackageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TutorInPackage",
                table: "TutorInPackage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Package",
                table: "Package",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TutorInPackage_Package_PackageId",
                table: "TutorInPackage",
                column: "PackageId",
                principalTable: "Package",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TutorInPackage_User_UserId",
                table: "TutorInPackage",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
