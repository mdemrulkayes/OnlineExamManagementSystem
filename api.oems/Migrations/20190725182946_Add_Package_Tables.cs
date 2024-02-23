using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.oems.Migrations
{
    public partial class Add_Package_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TutorEducationalInformations",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ResultId",
                table: "TutorEducationalInformations",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Package",
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
                    PackageName = table.Column<string>(nullable: true),
                    PackagePrice = table.Column<decimal>(nullable: false),
                    PackageDurationInDays = table.Column<int>(nullable: false),
                    PackageDescription = table.Column<string>(nullable: true),
                    IsShowPrice = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TutorInPackage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    PackageId = table.Column<int>(nullable: false),
                    ActivationStartDate = table.Column<DateTime>(nullable: false),
                    ActivationEndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorInPackage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TutorInPackage_Package_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TutorInPackage_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TutorTutionInformations_DaysPerWeekId",
                table: "TutorTutionInformations",
                column: "DaysPerWeekId");

            migrationBuilder.CreateIndex(
                name: "IX_TutorRequests_DaysPerWeekId",
                table: "TutorRequests",
                column: "DaysPerWeekId");

            migrationBuilder.CreateIndex(
                name: "IX_TutorEducationalInformations_EducationalLevelId",
                table: "TutorEducationalInformations",
                column: "EducationalLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_TutorEducationalInformations_ResultId",
                table: "TutorEducationalInformations",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_TutorEducationalInformations_UserId",
                table: "TutorEducationalInformations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TutorInPackage_PackageId",
                table: "TutorInPackage",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_TutorInPackage_UserId",
                table: "TutorInPackage",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TutorEducationalInformations_TutorCommonEntities_EducationalLevelId",
                table: "TutorEducationalInformations",
                column: "EducationalLevelId",
                principalTable: "TutorCommonEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TutorEducationalInformations_TutorCommonEntities_ResultId",
                table: "TutorEducationalInformations",
                column: "ResultId",
                principalTable: "TutorCommonEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TutorEducationalInformations_User_UserId",
                table: "TutorEducationalInformations",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TutorRequests_TutorCommonEntities_DaysPerWeekId",
                table: "TutorRequests",
                column: "DaysPerWeekId",
                principalTable: "TutorCommonEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TutorTutionInformations_TutorCommonEntities_DaysPerWeekId",
                table: "TutorTutionInformations",
                column: "DaysPerWeekId",
                principalTable: "TutorCommonEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TutorEducationalInformations_TutorCommonEntities_EducationalLevelId",
                table: "TutorEducationalInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_TutorEducationalInformations_TutorCommonEntities_ResultId",
                table: "TutorEducationalInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_TutorEducationalInformations_User_UserId",
                table: "TutorEducationalInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_TutorRequests_TutorCommonEntities_DaysPerWeekId",
                table: "TutorRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TutorTutionInformations_TutorCommonEntities_DaysPerWeekId",
                table: "TutorTutionInformations");

            migrationBuilder.DropTable(
                name: "TutorInPackage");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropIndex(
                name: "IX_TutorTutionInformations_DaysPerWeekId",
                table: "TutorTutionInformations");

            migrationBuilder.DropIndex(
                name: "IX_TutorRequests_DaysPerWeekId",
                table: "TutorRequests");

            migrationBuilder.DropIndex(
                name: "IX_TutorEducationalInformations_EducationalLevelId",
                table: "TutorEducationalInformations");

            migrationBuilder.DropIndex(
                name: "IX_TutorEducationalInformations_ResultId",
                table: "TutorEducationalInformations");

            migrationBuilder.DropIndex(
                name: "IX_TutorEducationalInformations_UserId",
                table: "TutorEducationalInformations");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TutorEducationalInformations",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ResultId",
                table: "TutorEducationalInformations",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
