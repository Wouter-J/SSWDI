using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AS_EFShelterData.Migrations
{
    public partial class AddedID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "InterestedAnimals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 1, 28, 16, 32, 2, 325, DateTimeKind.Local).AddTicks(4978));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 1, 28, 16, 32, 2, 329, DateTimeKind.Local).AddTicks(489));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 1, 28, 16, 32, 2, 329, DateTimeKind.Local).AddTicks(5426));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 1, 28, 16, 32, 2, 329, DateTimeKind.Local).AddTicks(6803));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID",
                table: "InterestedAnimals");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 1, 28, 15, 29, 19, 239, DateTimeKind.Local).AddTicks(197));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 1, 28, 15, 29, 19, 243, DateTimeKind.Local).AddTicks(2975));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 1, 28, 15, 29, 19, 243, DateTimeKind.Local).AddTicks(8129));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 1, 28, 15, 29, 19, 243, DateTimeKind.Local).AddTicks(9408));
        }
    }
}
