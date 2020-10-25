﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AS_EFShelterData.Migrations
{
    public partial class AgeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Firstname",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "RequiredAge",
                table: "Treatments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Costs",
                table: "Treatments",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

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
                columns: new[] { "Costs", "Date", "RequiredAge" },
                values: new object[] { 100, new DateTime(2020, 10, 25, 16, 18, 24, 719, DateTimeKind.Local).AddTicks(9409), 0.6f });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Costs", "Date", "RequiredAge" },
                values: new object[] { 100, new DateTime(2020, 10, 25, 16, 18, 24, 720, DateTimeKind.Local).AddTicks(836), 0.6f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Firstname",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "RequiredAge",
                table: "Treatments",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<decimal>(
                name: "Costs",
                table: "Treatments",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(int));

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
                columns: new[] { "Costs", "Date", "RequiredAge" },
                values: new object[] { 100.50m, new DateTime(2020, 10, 25, 12, 11, 46, 163, DateTimeKind.Local).AddTicks(220), 1 });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Costs", "Date", "RequiredAge" },
                values: new object[] { 100.50m, new DateTime(2020, 10, 25, 12, 11, 46, 163, DateTimeKind.Local).AddTicks(1566), 1 });
        }
    }
}
