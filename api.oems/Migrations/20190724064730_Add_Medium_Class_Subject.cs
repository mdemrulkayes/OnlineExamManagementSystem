using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.oems.Migrations
{
    public partial class Add_Medium_Class_Subject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TutorClasses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TutorMediums",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MediumName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorMediums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TutorSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubjectName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorSubjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassInMediums",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MediumId = table.Column<int>(nullable: true),
                    ClassId = table.Column<int>(nullable: true),
                    TutorClassId = table.Column<int>(nullable: true),
                    TutorMediumId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassInMediums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassInMediums_TutorClasses_TutorClassId",
                        column: x => x.TutorClassId,
                        principalTable: "TutorClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassInMediums_TutorMediums_TutorMediumId",
                        column: x => x.TutorMediumId,
                        principalTable: "TutorMediums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectInClasses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassId = table.Column<int>(nullable: true),
                    SubjectId = table.Column<int>(nullable: true),
                    TutorClassId = table.Column<int>(nullable: true),
                    TutorSubjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectInClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectInClasses_TutorClasses_TutorClassId",
                        column: x => x.TutorClassId,
                        principalTable: "TutorClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectInClasses_TutorSubjects_TutorSubjectId",
                        column: x => x.TutorSubjectId,
                        principalTable: "TutorSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassInMediums_TutorClassId",
                table: "ClassInMediums",
                column: "TutorClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassInMediums_TutorMediumId",
                table: "ClassInMediums",
                column: "TutorMediumId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectInClasses_TutorClassId",
                table: "SubjectInClasses",
                column: "TutorClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectInClasses_TutorSubjectId",
                table: "SubjectInClasses",
                column: "TutorSubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassInMediums");

            migrationBuilder.DropTable(
                name: "SubjectInClasses");

            migrationBuilder.DropTable(
                name: "TutorMediums");

            migrationBuilder.DropTable(
                name: "TutorClasses");

            migrationBuilder.DropTable(
                name: "TutorSubjects");
        }
    }
}
