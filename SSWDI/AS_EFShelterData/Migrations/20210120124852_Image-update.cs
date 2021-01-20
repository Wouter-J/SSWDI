using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AS_EFShelterData.Migrations
{
    public partial class Imageupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Animals",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 1, 20, 13, 48, 51, 61, DateTimeKind.Local).AddTicks(4891));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 1, 20, 13, 48, 51, 65, DateTimeKind.Local).AddTicks(3950));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 1, 20, 13, 48, 51, 65, DateTimeKind.Local).AddTicks(9027));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 1, 20, 13, 48, 51, 66, DateTimeKind.Local).AddTicks(993));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Animals");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 10, 25, 16, 18, 24, 713, DateTimeKind.Local).AddTicks(8729));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 10, 25, 16, 18, 24, 719, DateTimeKind.Local).AddTicks(4080));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 10, 25, 16, 18, 24, 719, DateTimeKind.Local).AddTicks(9409));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 10, 25, 16, 18, 24, 720, DateTimeKind.Local).AddTicks(836));
        }
    }
}
