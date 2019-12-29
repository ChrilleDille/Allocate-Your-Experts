using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllocateYourExperts.DataAccess.Migrations
{
    public partial class ProjectPropertyIsCompletedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Projects",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("81e6357e-f10e-4019-af7b-7f0141306166"),
                column: "IsCompleted",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Projects");
        }
    }
}
