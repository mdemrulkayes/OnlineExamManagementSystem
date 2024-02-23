using Microsoft.EntityFrameworkCore.Migrations;

namespace api.oems.Migrations
{
    public partial class Update_SubjectInClass_And_ClassInMidium : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassInMediums_TutorClasses_TutorClassId",
                table: "ClassInMediums");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassInMediums_TutorMediums_TutorMediumId",
                table: "ClassInMediums");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectInClasses_TutorClasses_TutorClassId",
                table: "SubjectInClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectInClasses_TutorSubjects_TutorSubjectId",
                table: "SubjectInClasses");

            migrationBuilder.DropIndex(
                name: "IX_SubjectInClasses_TutorClassId",
                table: "SubjectInClasses");

            migrationBuilder.DropIndex(
                name: "IX_SubjectInClasses_TutorSubjectId",
                table: "SubjectInClasses");

            migrationBuilder.DropIndex(
                name: "IX_ClassInMediums_TutorClassId",
                table: "ClassInMediums");

            migrationBuilder.DropIndex(
                name: "IX_ClassInMediums_TutorMediumId",
                table: "ClassInMediums");

            migrationBuilder.DropColumn(
                name: "TutorClassId",
                table: "SubjectInClasses");

            migrationBuilder.DropColumn(
                name: "TutorSubjectId",
                table: "SubjectInClasses");

            migrationBuilder.DropColumn(
                name: "TutorClassId",
                table: "ClassInMediums");

            migrationBuilder.DropColumn(
                name: "TutorMediumId",
                table: "ClassInMediums");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectInClasses_ClassId",
                table: "SubjectInClasses",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectInClasses_SubjectId",
                table: "SubjectInClasses",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassInMediums_ClassId",
                table: "ClassInMediums",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassInMediums_MediumId",
                table: "ClassInMediums",
                column: "MediumId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassInMediums_TutorClasses_ClassId",
                table: "ClassInMediums",
                column: "ClassId",
                principalTable: "TutorClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassInMediums_TutorMediums_MediumId",
                table: "ClassInMediums",
                column: "MediumId",
                principalTable: "TutorMediums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectInClasses_TutorClasses_ClassId",
                table: "SubjectInClasses",
                column: "ClassId",
                principalTable: "TutorClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectInClasses_TutorSubjects_SubjectId",
                table: "SubjectInClasses",
                column: "SubjectId",
                principalTable: "TutorSubjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassInMediums_TutorClasses_ClassId",
                table: "ClassInMediums");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassInMediums_TutorMediums_MediumId",
                table: "ClassInMediums");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectInClasses_TutorClasses_ClassId",
                table: "SubjectInClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectInClasses_TutorSubjects_SubjectId",
                table: "SubjectInClasses");

            migrationBuilder.DropIndex(
                name: "IX_SubjectInClasses_ClassId",
                table: "SubjectInClasses");

            migrationBuilder.DropIndex(
                name: "IX_SubjectInClasses_SubjectId",
                table: "SubjectInClasses");

            migrationBuilder.DropIndex(
                name: "IX_ClassInMediums_ClassId",
                table: "ClassInMediums");

            migrationBuilder.DropIndex(
                name: "IX_ClassInMediums_MediumId",
                table: "ClassInMediums");

            migrationBuilder.AddColumn<int>(
                name: "TutorClassId",
                table: "SubjectInClasses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TutorSubjectId",
                table: "SubjectInClasses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TutorClassId",
                table: "ClassInMediums",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TutorMediumId",
                table: "ClassInMediums",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubjectInClasses_TutorClassId",
                table: "SubjectInClasses",
                column: "TutorClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectInClasses_TutorSubjectId",
                table: "SubjectInClasses",
                column: "TutorSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassInMediums_TutorClassId",
                table: "ClassInMediums",
                column: "TutorClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassInMediums_TutorMediumId",
                table: "ClassInMediums",
                column: "TutorMediumId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassInMediums_TutorClasses_TutorClassId",
                table: "ClassInMediums",
                column: "TutorClassId",
                principalTable: "TutorClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassInMediums_TutorMediums_TutorMediumId",
                table: "ClassInMediums",
                column: "TutorMediumId",
                principalTable: "TutorMediums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectInClasses_TutorClasses_TutorClassId",
                table: "SubjectInClasses",
                column: "TutorClassId",
                principalTable: "TutorClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectInClasses_TutorSubjects_TutorSubjectId",
                table: "SubjectInClasses",
                column: "TutorSubjectId",
                principalTable: "TutorSubjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
