using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AS_EFShelterData.Migrations
{
    public partial class AddedUserlink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Users_UserID",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_UserID",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "InterestedUser",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Animals");

            migrationBuilder.AddColumn<int>(
                name: "InderestedUserID",
                table: "Animals",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "ID",
                keyValue: 1,
                column: "InderestedUserID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "ID",
                keyValue: 2,
                column: "Gender",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "InterestedUser",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Animals",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "ID",
                keyValue: 1,
                column: "InterestedUser",
                value: "wouterjansen97@gmail.com");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "ID",
                keyValue: 2,
                column: "Gender",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 1, 24, 13, 16, 40, 937, DateTimeKind.Local).AddTicks(9792));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 1, 24, 13, 16, 40, 942, DateTimeKind.Local).AddTicks(1192));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 1, 24, 13, 16, 40, 942, DateTimeKind.Local).AddTicks(6440));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 1, 24, 13, 16, 40, 942, DateTimeKind.Local).AddTicks(7736));

            migrationBuilder.CreateIndex(
                name: "IX_Animals_UserID",
                table: "Animals",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Users_UserID",
                table: "Animals",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
