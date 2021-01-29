using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AS_EFShelterData.Migrations
{
    public partial class UpdatedInterestedAnimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestedAnimals_Users_AnimalID",
                table: "InterestedAnimals");

            migrationBuilder.DropForeignKey(
                name: "FK_InterestedAnimals_Animals_UserID",
                table: "InterestedAnimals");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 1, 28, 20, 0, 24, 51, DateTimeKind.Local).AddTicks(4901));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 1, 28, 20, 0, 24, 57, DateTimeKind.Local).AddTicks(1477));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 1, 28, 20, 0, 24, 57, DateTimeKind.Local).AddTicks(6677));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 1, 28, 20, 0, 24, 58, DateTimeKind.Local).AddTicks(3273));

            migrationBuilder.AddForeignKey(
                name: "FK_InterestedAnimals_Animals_AnimalID",
                table: "InterestedAnimals",
                column: "AnimalID",
                principalTable: "Animals",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterestedAnimals_Users_UserID",
                table: "InterestedAnimals",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestedAnimals_Animals_AnimalID",
                table: "InterestedAnimals");

            migrationBuilder.DropForeignKey(
                name: "FK_InterestedAnimals_Users_UserID",
                table: "InterestedAnimals");

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

            migrationBuilder.AddForeignKey(
                name: "FK_InterestedAnimals_Users_AnimalID",
                table: "InterestedAnimals",
                column: "AnimalID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterestedAnimals_Animals_UserID",
                table: "InterestedAnimals",
                column: "UserID",
                principalTable: "Animals",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
