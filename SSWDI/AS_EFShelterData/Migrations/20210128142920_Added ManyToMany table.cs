using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AS_EFShelterData.Migrations
{
    public partial class AddedManyToManytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Users_InderestedUserID",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_InderestedUserID",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "InderestedUserID",
                table: "Animals");

            migrationBuilder.AddColumn<int>(
                name: "InterestCount",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "InterestedAnimals",
                columns: table => new
                {
                    AnimalID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestedAnimals", x => new { x.AnimalID, x.UserID });
                    table.ForeignKey(
                        name: "FK_InterestedAnimals_Users_AnimalID",
                        column: x => x.AnimalID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestedAnimals_Animals_UserID",
                        column: x => x.UserID,
                        principalTable: "Animals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_InterestedAnimals_UserID",
                table: "InterestedAnimals",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestedAnimals");

            migrationBuilder.DropColumn(
                name: "InterestCount",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "InderestedUserID",
                table: "Animals",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "ID",
                keyValue: 1,
                column: "InderestedUserID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 1, 24, 21, 4, 33, 774, DateTimeKind.Local).AddTicks(7249));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 1, 24, 21, 4, 33, 779, DateTimeKind.Local).AddTicks(5409));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 1, 24, 21, 4, 33, 780, DateTimeKind.Local).AddTicks(658));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 1, 24, 21, 4, 33, 780, DateTimeKind.Local).AddTicks(1927));

            migrationBuilder.CreateIndex(
                name: "IX_Animals_InderestedUserID",
                table: "Animals",
                column: "InderestedUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Users_InderestedUserID",
                table: "Animals",
                column: "InderestedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
