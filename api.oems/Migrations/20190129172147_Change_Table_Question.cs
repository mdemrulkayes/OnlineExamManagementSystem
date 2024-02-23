using Microsoft.EntityFrameworkCore.Migrations;

namespace api.oems.Migrations
{
    public partial class Change_Table_Question : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "FullMark",
                table: "QuestionSets",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PassedMark",
                table: "QuestionSets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullMark",
                table: "QuestionSets");

            migrationBuilder.DropColumn(
                name: "PassedMark",
                table: "QuestionSets");
        }
    }
}
