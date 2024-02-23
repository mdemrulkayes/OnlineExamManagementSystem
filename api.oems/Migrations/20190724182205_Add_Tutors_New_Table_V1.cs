using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.oems.Migrations
{
    public partial class Add_Tutors_New_Table_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TutorEducationalInformations",
                columns: table => new
                {
                    IsActive = table.Column<bool>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    EducationalLevelId = table.Column<int>(nullable: false),
                    GroupOrSubject = table.Column<string>(nullable: true),
                    InstituteName = table.Column<string>(nullable: true),
                    ResultId = table.Column<string>(nullable: true),
                    GradePoint = table.Column<decimal>(nullable: false),
                    PassingYear = table.Column<int>(nullable: false),
                    Achivement = table.Column<string>(nullable: true),
                    DocumentLocation = table.Column<string>(nullable: true),
                    DocumentationData = table.Column<byte[]>(nullable: true),
                    DocumentFormat = table.Column<string>(nullable: true),
                    IsDocumentValid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorEducationalInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TutorPersonalInformations",
                columns: table => new
                {
                    IsActive = table.Column<bool>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserReferenceId = table.Column<long>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    IsEmailVarified = table.Column<bool>(nullable: false),
                    IsMobilePhoneVarified = table.Column<bool>(nullable: false),
                    BloodGroup = table.Column<int>(nullable: false),
                    MaritialStatus = table.Column<int>(nullable: false),
                    Experience = table.Column<string>(nullable: true),
                    LastLoginDate = table.Column<DateTime>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    Religion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorPersonalInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TutorPersonalInformations_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TutorRequests",
                columns: table => new
                {
                    IsActive = table.Column<bool>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DistrictId = table.Column<int>(nullable: false),
                    AreaId = table.Column<int>(nullable: false),
                    MediumId = table.Column<int>(nullable: false),
                    ClassId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    StudentInstituteName = table.Column<string>(nullable: true),
                    DaysPerWeekId = table.Column<int>(nullable: false),
                    StudentGender = table.Column<int>(nullable: false),
                    SalaryRangeId = table.Column<int>(nullable: false),
                    TutorGender = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    AdditionalInformation = table.Column<string>(nullable: true),
                    ValidateTo = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TutorRequests_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TutorRequests_TutorClasses_ClassId",
                        column: x => x.ClassId,
                        principalTable: "TutorClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TutorRequests_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TutorRequests_TutorMediums_MediumId",
                        column: x => x.MediumId,
                        principalTable: "TutorMediums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TutorRequests_TutorCommonEntities_SalaryRangeId",
                        column: x => x.SalaryRangeId,
                        principalTable: "TutorCommonEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TutorRequests_TutorSubjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "TutorSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TutorTutionInformations",
                columns: table => new
                {
                    IsActive = table.Column<bool>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    HigherEducationalDegreeName = table.Column<string>(nullable: true),
                    HigherEducationalInstitute = table.Column<string>(nullable: true),
                    ExpectedSalary = table.Column<decimal>(nullable: false),
                    IsSalaryNegotiable = table.Column<bool>(nullable: false),
                    IsGroupTution = table.Column<bool>(nullable: false),
                    IsPrivateTution = table.Column<bool>(nullable: false),
                    IsTutionInClassRoom = table.Column<bool>(nullable: false),
                    IsTutionInCoachingCenter = table.Column<bool>(nullable: false),
                    IsTutionInHomeVisit = table.Column<bool>(nullable: false),
                    IsInTutorPlace = table.Column<bool>(nullable: false),
                    IsProvideOnlineHelp = table.Column<bool>(nullable: false),
                    IsProvidePhoneHelp = table.Column<bool>(nullable: false),
                    IsProvideHandNotes = table.Column<bool>(nullable: false),
                    IsProvideVideoTutorials = table.Column<bool>(nullable: false),
                    DaysPerWeekId = table.Column<int>(nullable: false),
                    PreferredDistrictId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorTutionInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TutorTutionInformations_Districts_PreferredDistrictId",
                        column: x => x.PreferredDistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TutorTutionInformations_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TutorPersonalInformations_UserId",
                table: "TutorPersonalInformations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TutorRequests_AreaId",
                table: "TutorRequests",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_TutorRequests_ClassId",
                table: "TutorRequests",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_TutorRequests_DistrictId",
                table: "TutorRequests",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_TutorRequests_MediumId",
                table: "TutorRequests",
                column: "MediumId");

            migrationBuilder.CreateIndex(
                name: "IX_TutorRequests_SalaryRangeId",
                table: "TutorRequests",
                column: "SalaryRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_TutorRequests_SubjectId",
                table: "TutorRequests",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TutorTutionInformations_PreferredDistrictId",
                table: "TutorTutionInformations",
                column: "PreferredDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_TutorTutionInformations_UserId",
                table: "TutorTutionInformations",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TutorEducationalInformations");

            migrationBuilder.DropTable(
                name: "TutorPersonalInformations");

            migrationBuilder.DropTable(
                name: "TutorRequests");

            migrationBuilder.DropTable(
                name: "TutorTutionInformations");
        }
    }
}
