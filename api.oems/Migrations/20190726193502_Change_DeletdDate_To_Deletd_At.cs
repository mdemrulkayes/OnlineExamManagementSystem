using Microsoft.EntityFrameworkCore.Migrations;

namespace api.oems.Migrations
{
    public partial class Change_DeletdDate_To_Deletd_At : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "TutorTutionInformations",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "TutorSubjects",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "TutorRequests",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "TutorPersonalInformations",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "TutorMediums",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "TutorEducationalInformations",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "TutorClasses",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "Packages",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "Districts",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "Areas",
                newName: "DeletedAt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "TutorTutionInformations",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "TutorSubjects",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "TutorRequests",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "TutorPersonalInformations",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "TutorMediums",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "TutorEducationalInformations",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "TutorClasses",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Packages",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Districts",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Areas",
                newName: "DeletedDate");
        }
    }
}
