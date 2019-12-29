using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllocateYourExperts.DataAccess.Migrations
{
    public partial class expertPropertyFirstAndLastNameAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Experts");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Experts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Experts",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: new Guid("0023e810-eb0a-4309-9b9a-55f4656cddb4"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Robin", "Törna" });

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: new Guid("28e9d5c5-623d-4d9d-94bc-c03891384daa"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Anton", "Andersson" });

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: new Guid("3fe1f89f-ead1-4f4c-ba58-6d8cf5ae31be"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Håkan", "Fridolfsson" });

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: new Guid("603212be-05a5-4ea3-956d-94b83438fd8a"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Henrik", "Holmqvist" });

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: new Guid("91f29e45-000a-46c4-93ac-bf50d6bb6164"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Josefine", "Flygmaskin" });

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: new Guid("a5794b8e-4dca-4b3b-8691-351c76740826"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Veronica", "Molin" });

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: new Guid("c94570ab-a13b-45f6-aec1-fc4994f7da17"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Christian", "Griffin" });

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: new Guid("e0a47365-6e76-4ed8-9504-7bee877a31d5"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Mirela", "Flummoic" });

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: new Guid("f066fcbb-ebd2-4018-a38c-56e5b02047bd"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Jonas", "Argman" });

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: new Guid("fa1a4754-9dc6-4ecc-8cef-61f9624249bb"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Lena", "Tapper" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Experts");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Experts");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Experts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: new Guid("0023e810-eb0a-4309-9b9a-55f4656cddb4"),
                column: "Name",
                value: "Robin");

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: new Guid("28e9d5c5-623d-4d9d-94bc-c03891384daa"),
                column: "Name",
                value: "Anton");

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: new Guid("3fe1f89f-ead1-4f4c-ba58-6d8cf5ae31be"),
                column: "Name",
                value: "Håkan");

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: new Guid("603212be-05a5-4ea3-956d-94b83438fd8a"),
                column: "Name",
                value: "Henrik");

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: new Guid("91f29e45-000a-46c4-93ac-bf50d6bb6164"),
                column: "Name",
                value: "Josefine");

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: new Guid("a5794b8e-4dca-4b3b-8691-351c76740826"),
                column: "Name",
                value: "Veronica");

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: new Guid("c94570ab-a13b-45f6-aec1-fc4994f7da17"),
                column: "Name",
                value: "Christian");

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: new Guid("e0a47365-6e76-4ed8-9504-7bee877a31d5"),
                column: "Name",
                value: "Mirela");

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: new Guid("f066fcbb-ebd2-4018-a38c-56e5b02047bd"),
                column: "Name",
                value: "Jonas");

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: new Guid("fa1a4754-9dc6-4ecc-8cef-61f9624249bb"),
                column: "Name",
                value: "Lena");
        }
    }
}
