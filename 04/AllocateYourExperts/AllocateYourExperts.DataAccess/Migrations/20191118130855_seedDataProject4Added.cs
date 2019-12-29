using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllocateYourExperts.DataAccess.Migrations
{
    public partial class seedDataProject4Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "EndDate", "IsActive", "IsCompleted", "Name", "StartDate" },
                values: new object[] { new Guid("08271ef0-710d-4208-8ae0-bffc5d5a07cd"), new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "Project 4", new DateTime(2019, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ProjectExpertRole",
                columns: new[] { "ExpertId", "ProjectId", "RoleId" },
                values: new object[] { new Guid("c94570ab-a13b-45f6-aec1-fc4994f7da17"), new Guid("08271ef0-710d-4208-8ae0-bffc5d5a07cd"), new Guid("757e44bb-84a9-4457-adc1-85d3a323ffb0") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectExpertRole",
                keyColumns: new[] { "ExpertId", "ProjectId", "RoleId" },
                keyValues: new object[] { new Guid("c94570ab-a13b-45f6-aec1-fc4994f7da17"), new Guid("08271ef0-710d-4208-8ae0-bffc5d5a07cd"), new Guid("757e44bb-84a9-4457-adc1-85d3a323ffb0") });

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("08271ef0-710d-4208-8ae0-bffc5d5a07cd"));
        }
    }
}
