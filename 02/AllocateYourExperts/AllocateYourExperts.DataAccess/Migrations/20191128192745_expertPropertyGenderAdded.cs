using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllocateYourExperts.DataAccess.Migrations
{
    public partial class expertPropertyGenderAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Experts",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: new Guid("0023e810-eb0a-4309-9b9a-55f4656cddb4"),
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: new Guid("28e9d5c5-623d-4d9d-94bc-c03891384daa"),
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: new Guid("3fe1f89f-ead1-4f4c-ba58-6d8cf5ae31be"),
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: new Guid("603212be-05a5-4ea3-956d-94b83438fd8a"),
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: new Guid("91f29e45-000a-46c4-93ac-bf50d6bb6164"),
                column: "Gender",
                value: "Female");

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: new Guid("a5794b8e-4dca-4b3b-8691-351c76740826"),
                column: "Gender",
                value: "Female");

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: new Guid("c94570ab-a13b-45f6-aec1-fc4994f7da17"),
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: new Guid("e0a47365-6e76-4ed8-9504-7bee877a31d5"),
                column: "Gender",
                value: "Female");

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: new Guid("f066fcbb-ebd2-4018-a38c-56e5b02047bd"),
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: new Guid("fa1a4754-9dc6-4ecc-8cef-61f9624249bb"),
                column: "Gender",
                value: "Female");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Experts");
        }
    }
}
