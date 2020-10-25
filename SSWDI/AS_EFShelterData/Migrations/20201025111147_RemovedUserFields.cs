using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AS_EFShelterData.Migrations
{
    public partial class RemovedUserFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 10, 25, 12, 11, 46, 157, DateTimeKind.Local).AddTicks(3687));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 10, 25, 12, 11, 46, 162, DateTimeKind.Local).AddTicks(2539));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 10, 25, 12, 11, 46, 163, DateTimeKind.Local).AddTicks(220));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 10, 25, 12, 11, 46, 163, DateTimeKind.Local).AddTicks(1566));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 10, 25, 11, 21, 40, 405, DateTimeKind.Local).AddTicks(6720));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 10, 25, 11, 21, 40, 409, DateTimeKind.Local).AddTicks(4442));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 10, 25, 11, 21, 40, 409, DateTimeKind.Local).AddTicks(9316));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 10, 25, 11, 21, 40, 410, DateTimeKind.Local).AddTicks(4672));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CustomerID", "Password" },
                values: new object[] { 1, "12345678" });
        }
    }
}
