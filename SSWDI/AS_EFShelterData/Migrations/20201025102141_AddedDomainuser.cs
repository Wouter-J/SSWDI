using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AS_EFShelterData.Migrations
{
    public partial class AddedDomainuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Stays",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InterestedUser",
                table: "Animals",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Animals",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(nullable: false),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Cellphone = table.Column<string>(nullable: true),
                    BirthDay = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "ID",
                keyValue: 1,
                column: "InterestedUser",
                value: "wouterjansen97@gmail.com");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 10, 25, 11, 21, 40, 405, DateTimeKind.Local).AddTicks(6720));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 10, 25, 11, 21, 40, 409, DateTimeKind.Local).AddTicks(4442));

            migrationBuilder.UpdateData(
                table: "Stays",
                keyColumn: "ID",
                keyValue: 1,
                column: "AdoptedBy",
                value: "wouterjansen97@gmail.com");

            migrationBuilder.UpdateData(
                table: "Stays",
                keyColumn: "ID",
                keyValue: 2,
                column: "AdoptedBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 10, 25, 11, 21, 40, 409, DateTimeKind.Local).AddTicks(9316));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 10, 25, 11, 21, 40, 410, DateTimeKind.Local).AddTicks(4672));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Address", "BirthDay", "Cellphone", "CustomerID", "Email", "Firstname", "Lastname", "Password", "PostalCode" },
                values: new object[] { 1, "Kloostergang 326", new DateTime(1997, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "0612345678", 1, "wouterjansen97@gmail.com", "Wouter", "Jansen", "12345678", "4201JA" });

            migrationBuilder.CreateIndex(
                name: "IX_Stays_UserID",
                table: "Stays",
                column: "UserID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Stays_Users_UserID",
                table: "Stays",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Users_UserID",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Stays_Users_UserID",
                table: "Stays");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Stays_UserID",
                table: "Stays");

            migrationBuilder.DropIndex(
                name: "IX_Animals_UserID",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Stays");

            migrationBuilder.DropColumn(
                name: "InterestedUser",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Animals");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 10, 21, 22, 23, 8, 93, DateTimeKind.Local).AddTicks(8461));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 10, 21, 22, 23, 8, 98, DateTimeKind.Local).AddTicks(4227));

            migrationBuilder.UpdateData(
                table: "Stays",
                keyColumn: "ID",
                keyValue: 1,
                column: "AdoptedBy",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stays",
                keyColumn: "ID",
                keyValue: 2,
                column: "AdoptedBy",
                value: "");

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 10, 21, 22, 23, 8, 98, DateTimeKind.Local).AddTicks(9960));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 10, 21, 22, 23, 8, 99, DateTimeKind.Local).AddTicks(1293));
        }
    }
}
