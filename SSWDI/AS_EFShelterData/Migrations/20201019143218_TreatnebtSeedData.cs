using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AS_EFShelterData.Migrations
{
    public partial class TreatnebtSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_Stays_StayID",
                table: "Treatments");

            migrationBuilder.AlterColumn<int>(
                name: "StayID",
                table: "Treatments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 10, 19, 16, 32, 18, 241, DateTimeKind.Local).AddTicks(9440));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 10, 19, 16, 32, 18, 245, DateTimeKind.Local).AddTicks(7711));

            migrationBuilder.InsertData(
                table: "Treatments",
                columns: new[] { "ID", "Costs", "Date", "Description", "DoneBy", "RequiredAge", "StayID", "TreatmentType" },
                values: new object[,]
                {
                    { 1, 100.50m, new DateTime(2020, 10, 19, 16, 32, 18, 246, DateTimeKind.Local).AddTicks(2703), "Inenting voor ziekte x", "Some Person", 1, 1, 2 },
                    { 2, 100.50m, new DateTime(2020, 10, 19, 16, 32, 18, 246, DateTimeKind.Local).AddTicks(4034), "Removed lasagna from stomach", "Some Person", 1, 2, 3 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_Stays_StayID",
                table: "Treatments",
                column: "StayID",
                principalTable: "Stays",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_Stays_StayID",
                table: "Treatments");

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "StayID",
                table: "Treatments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 10, 19, 16, 27, 39, 842, DateTimeKind.Local).AddTicks(6991));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 10, 19, 16, 27, 39, 846, DateTimeKind.Local).AddTicks(1410));

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_Stays_StayID",
                table: "Treatments",
                column: "StayID",
                principalTable: "Stays",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
