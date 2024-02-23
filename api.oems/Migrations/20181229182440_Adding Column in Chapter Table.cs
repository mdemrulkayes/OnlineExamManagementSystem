using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.oems.Migrations
{
    public partial class AddingColumninChapterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRequestRejected",
                table: "UserInstituteJoinRequests",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Chapters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Chapters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "Chapters",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_CreatedByUserId",
                table: "Chapters",
                column: "CreatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chapters_User_CreatedByUserId",
                table: "Chapters",
                column: "CreatedByUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapters_User_CreatedByUserId",
                table: "Chapters");

            migrationBuilder.DropIndex(
                name: "IX_Chapters_CreatedByUserId",
                table: "Chapters");

            migrationBuilder.DropColumn(
                name: "IsRequestRejected",
                table: "UserInstituteJoinRequests");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Chapters");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Chapters");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Chapters");
        }
    }
}
