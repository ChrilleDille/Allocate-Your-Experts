using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllocateYourExperts.DataAccess.Migrations
{
    public partial class seedDatabaseWithANewMemberOfProject3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProjectExpertRole",
                columns: new[] { "ExpertId", "ProjectId", "RoleId" },
                values: new object[] { new Guid("3fe1f89f-ead1-4f4c-ba58-6d8cf5ae31be"), new Guid("e7819413-0aa7-4885-b45e-d3a8ecbc4339"), new Guid("757e44bb-84a9-4457-adc1-85d3a323ffb0") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectExpertRole",
                keyColumns: new[] { "ExpertId", "ProjectId", "RoleId" },
                keyValues: new object[] { new Guid("3fe1f89f-ead1-4f4c-ba58-6d8cf5ae31be"), new Guid("e7819413-0aa7-4885-b45e-d3a8ecbc4339"), new Guid("757e44bb-84a9-4457-adc1-85d3a323ffb0") });
        }
    }
}
