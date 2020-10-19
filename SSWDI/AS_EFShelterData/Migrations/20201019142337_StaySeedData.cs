using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AS_EFShelterData.Migrations
{
    public partial class StaySeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Stays_StayID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Stays_Animals_AnimalID",
                table: "Stays");

            migrationBuilder.DropForeignKey(
                name: "FK_Stays_Lodgings_LodgingLocationID",
                table: "Stays");

            migrationBuilder.AlterColumn<int>(
                name: "LodgingLocationID",
                table: "Stays",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnimalID",
                table: "Stays",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StayID",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Stays",
                columns: new[] { "ID", "AdoptedBy", "AdoptionDate", "AnimalID", "ArrivalDate", "CanBeAdopted", "LodgingLocationID" },
                values: new object[] { 1, "", null, 1, new DateTime(2019, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1 });

            migrationBuilder.InsertData(
                table: "Stays",
                columns: new[] { "ID", "AdoptedBy", "AdoptionDate", "AnimalID", "ArrivalDate", "CanBeAdopted", "LodgingLocationID" },
                values: new object[] { 2, "", null, 2, new DateTime(2019, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2 });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Stays_StayID",
                table: "Comments",
                column: "StayID",
                principalTable: "Stays",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stays_Animals_AnimalID",
                table: "Stays",
                column: "AnimalID",
                principalTable: "Animals",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stays_Lodgings_LodgingLocationID",
                table: "Stays",
                column: "LodgingLocationID",
                principalTable: "Lodgings",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Stays_StayID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Stays_Animals_AnimalID",
                table: "Stays");

            migrationBuilder.DropForeignKey(
                name: "FK_Stays_Lodgings_LodgingLocationID",
                table: "Stays");

            migrationBuilder.DeleteData(
                table: "Stays",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stays",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "LodgingLocationID",
                table: "Stays",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AnimalID",
                table: "Stays",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "StayID",
                table: "Comments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Stays_StayID",
                table: "Comments",
                column: "StayID",
                principalTable: "Stays",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stays_Animals_AnimalID",
                table: "Stays",
                column: "AnimalID",
                principalTable: "Animals",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stays_Lodgings_LodgingLocationID",
                table: "Stays",
                column: "LodgingLocationID",
                principalTable: "Lodgings",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
