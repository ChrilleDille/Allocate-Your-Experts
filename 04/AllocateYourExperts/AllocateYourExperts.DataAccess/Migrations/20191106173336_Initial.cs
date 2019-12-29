using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllocateYourExperts.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Experts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectExpertRole",
                columns: table => new
                {
                    ExpertId = table.Column<Guid>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectExpertRole", x => new { x.ExpertId, x.ProjectId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_ProjectExpertRole_Experts_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Experts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectExpertRole_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectExpertRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Experts",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("c94570ab-a13b-45f6-aec1-fc4994f7da17"), "Christian" },
                    { new Guid("e0a47365-6e76-4ed8-9504-7bee877a31d5"), "Mirela" },
                    { new Guid("28e9d5c5-623d-4d9d-94bc-c03891384daa"), "Anton" },
                    { new Guid("fa1a4754-9dc6-4ecc-8cef-61f9624249bb"), "Lena" },
                    { new Guid("3fe1f89f-ead1-4f4c-ba58-6d8cf5ae31be"), "Håkan" },
                    { new Guid("91f29e45-000a-46c4-93ac-bf50d6bb6164"), "Josefine" },
                    { new Guid("603212be-05a5-4ea3-956d-94b83438fd8a"), "Henrik" },
                    { new Guid("a5794b8e-4dca-4b3b-8691-351c76740826"), "Veronica" },
                    { new Guid("0023e810-eb0a-4309-9b9a-55f4656cddb4"), "Robin" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "EndDate", "IsActive", "Name", "StartDate" },
                values: new object[,]
                {
                    { new Guid("81e6357e-f10e-4019-af7b-7f0141306166"), new DateTime(2019, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Project 1", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1e4d6c43-7998-4f94-a06c-1db42db4cc55"), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Project 2", new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e7819413-0aa7-4885-b45e-d3a8ecbc4339"), new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Project 3", new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("757e44bb-84a9-4457-adc1-85d3a323ffb0"), "Leader" },
                    { new Guid("c0aa725f-3804-4fe9-a51f-74c3e7780475"), "Member" }
                });

            migrationBuilder.InsertData(
                table: "ProjectExpertRole",
                columns: new[] { "ExpertId", "ProjectId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("c94570ab-a13b-45f6-aec1-fc4994f7da17"), new Guid("81e6357e-f10e-4019-af7b-7f0141306166"), new Guid("757e44bb-84a9-4457-adc1-85d3a323ffb0") },
                    { new Guid("a5794b8e-4dca-4b3b-8691-351c76740826"), new Guid("1e4d6c43-7998-4f94-a06c-1db42db4cc55"), new Guid("757e44bb-84a9-4457-adc1-85d3a323ffb0") },
                    { new Guid("fa1a4754-9dc6-4ecc-8cef-61f9624249bb"), new Guid("81e6357e-f10e-4019-af7b-7f0141306166"), new Guid("c0aa725f-3804-4fe9-a51f-74c3e7780475") },
                    { new Guid("603212be-05a5-4ea3-956d-94b83438fd8a"), new Guid("81e6357e-f10e-4019-af7b-7f0141306166"), new Guid("c0aa725f-3804-4fe9-a51f-74c3e7780475") },
                    { new Guid("3fe1f89f-ead1-4f4c-ba58-6d8cf5ae31be"), new Guid("1e4d6c43-7998-4f94-a06c-1db42db4cc55"), new Guid("c0aa725f-3804-4fe9-a51f-74c3e7780475") },
                    { new Guid("0023e810-eb0a-4309-9b9a-55f4656cddb4"), new Guid("1e4d6c43-7998-4f94-a06c-1db42db4cc55"), new Guid("c0aa725f-3804-4fe9-a51f-74c3e7780475") },
                    { new Guid("e0a47365-6e76-4ed8-9504-7bee877a31d5"), new Guid("e7819413-0aa7-4885-b45e-d3a8ecbc4339"), new Guid("c0aa725f-3804-4fe9-a51f-74c3e7780475") },
                    { new Guid("c94570ab-a13b-45f6-aec1-fc4994f7da17"), new Guid("e7819413-0aa7-4885-b45e-d3a8ecbc4339"), new Guid("c0aa725f-3804-4fe9-a51f-74c3e7780475") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectExpertRole_ProjectId",
                table: "ProjectExpertRole",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectExpertRole_RoleId",
                table: "ProjectExpertRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectExpertRole");

            migrationBuilder.DropTable(
                name: "Experts");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
