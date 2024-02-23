using Microsoft.EntityFrameworkCore.Migrations;

namespace api.oems.Migrations
{
    public partial class ChangeTableNameOfCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesInInstitute_Category_CategoryId",
                table: "CategoriesInInstitute");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesInInstitute_Subjects_SubjectId",
                table: "CategoriesInInstitute");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_User_CreatedBy",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_CategoriesInInstitute_SubjectId",
                table: "CategoriesInInstitute");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "CategoriesInInstitute");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_Category_CreatedBy",
                table: "Categories",
                newName: "IX_Categories_CreatedBy");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Subjects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_CategoryId",
                table: "Subjects",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_User_CreatedBy",
                table: "Categories",
                column: "CreatedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesInInstitute_Categories_CategoryId",
                table: "CategoriesInInstitute",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Categories_CategoryId",
                table: "Subjects",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_User_CreatedBy",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesInInstitute_Categories_CategoryId",
                table: "CategoriesInInstitute");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Categories_CategoryId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_CategoryId",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Subjects");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_CreatedBy",
                table: "Category",
                newName: "IX_Category_CreatedBy");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "CategoriesInInstitute",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesInInstitute_SubjectId",
                table: "CategoriesInInstitute",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesInInstitute_Category_CategoryId",
                table: "CategoriesInInstitute",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesInInstitute_Subjects_SubjectId",
                table: "CategoriesInInstitute",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_User_CreatedBy",
                table: "Category",
                column: "CreatedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
