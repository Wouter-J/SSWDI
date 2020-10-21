using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AS_EFShelterData.Migrations
{
    public partial class AddedDescriptionToLodge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Lodgings",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 10, 21, 21, 56, 34, 726, DateTimeKind.Local).AddTicks(9311));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 10, 21, 21, 56, 34, 730, DateTimeKind.Local).AddTicks(7327));

            migrationBuilder.UpdateData(
                table: "Lodgings",
                keyColumn: "ID",
                keyValue: 1,
                column: "Description",
                value: "Grote opvang voor Honden ");

            migrationBuilder.UpdateData(
                table: "Lodgings",
                keyColumn: "ID",
                keyValue: 2,
                column: "Description",
                value: "Grote opvang voor Katten ");

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 10, 21, 21, 56, 34, 731, DateTimeKind.Local).AddTicks(2640));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 10, 21, 21, 56, 34, 731, DateTimeKind.Local).AddTicks(3946));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Lodgings");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 10, 21, 17, 17, 0, 223, DateTimeKind.Local).AddTicks(136));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 10, 21, 17, 17, 0, 226, DateTimeKind.Local).AddTicks(3655));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 10, 21, 17, 17, 0, 226, DateTimeKind.Local).AddTicks(8421));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 10, 21, 17, 17, 0, 226, DateTimeKind.Local).AddTicks(9690));
        }
    }
}
