using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllocateYourExperts.DataAccess.Migrations
{
    public partial class seedDatabaseDataAddedJonas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Experts",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[] { new Guid("f066fcbb-ebd2-4018-a38c-56e5b02047bd"), "jonas@somemail.com", "Jonas" });

            migrationBuilder.InsertData(
                table: "ProjectExpertRole",
                columns: new[] { "ExpertId", "ProjectId", "RoleId" },
                values: new object[] { new Guid("f066fcbb-ebd2-4018-a38c-56e5b02047bd"), new Guid("08271ef0-710d-4208-8ae0-bffc5d5a07cd"), new Guid("c0aa725f-3804-4fe9-a51f-74c3e7780475") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectExpertRole",
                keyColumns: new[] { "ExpertId", "ProjectId", "RoleId" },
                keyValues: new object[] { new Guid("f066fcbb-ebd2-4018-a38c-56e5b02047bd"), new Guid("08271ef0-710d-4208-8ae0-bffc5d5a07cd"), new Guid("c0aa725f-3804-4fe9-a51f-74c3e7780475") });

            migrationBuilder.DeleteData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: new Guid("f066fcbb-ebd2-4018-a38c-56e5b02047bd"));
        }
    }
}
