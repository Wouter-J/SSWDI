using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AS_EFShelterData.Migrations
{
    public partial class CommentSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Stays_StayID",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "StayID",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "ID", "Content", "Date", "StayID", "WrittenBy" },
                values: new object[] { 1, "Cool doggo", new DateTime(2020, 10, 19, 16, 27, 39, 842, DateTimeKind.Local).AddTicks(6991), 1, "Barry" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "ID", "Content", "Date", "StayID", "WrittenBy" },
                values: new object[] { 2, "Ate all the lasagna", new DateTime(2020, 10, 19, 16, 27, 39, 846, DateTimeKind.Local).AddTicks(1410), 2, "Barry" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Stays_StayID",
                table: "Comments",
                column: "StayID",
                principalTable: "Stays",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Stays_StayID",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "StayID",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Stays_StayID",
                table: "Comments",
                column: "StayID",
                principalTable: "Stays",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
