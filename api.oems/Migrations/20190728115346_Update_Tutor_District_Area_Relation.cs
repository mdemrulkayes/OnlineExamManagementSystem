using Microsoft.EntityFrameworkCore.Migrations;

namespace api.oems.Migrations
{
    public partial class Update_Tutor_District_Area_Relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "Areas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Areas_DistrictId",
                table: "Areas",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Districts_DistrictId",
                table: "Areas",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Districts_DistrictId",
                table: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_Areas_DistrictId",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "Areas");
        }
    }
}
