﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AS_EFShelterData.Migrations
{
    public partial class ManyToManyRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Stays_ID",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "AnimalStay");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stays",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Comments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AdoptionDate",
                table: "Stays",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "AnimalID",
                table: "Stays",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentCapacity",
                table: "Lodgings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CommentID",
                table: "Comments",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "StayID",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "CommentID");

            migrationBuilder.UpdateData(
                table: "Lodgings",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CurrentCapacity", "MaxCapacity" },
                values: new object[] { 10, 100 });

            migrationBuilder.InsertData(
                table: "Lodgings",
                columns: new[] { "ID", "AnimalType", "CurrentCapacity", "LodgingType", "MaxCapacity" },
                values: new object[] { 2, 1, 10, 0, 100 });

            migrationBuilder.CreateIndex(
                name: "IX_Stays_AnimalID",
                table: "Stays",
                column: "AnimalID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_StayID",
                table: "Comments",
                column: "StayID");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Stays_StayID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Stays_Animals_AnimalID",
                table: "Stays");

            migrationBuilder.DropIndex(
                name: "IX_Stays_AnimalID",
                table: "Stays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_StayID",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "Lodgings",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "AnimalID",
                table: "Stays");

            migrationBuilder.DropColumn(
                name: "CurrentCapacity",
                table: "Lodgings");

            migrationBuilder.DropColumn(
                name: "CommentID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "StayID",
                table: "Comments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AdoptionDate",
                table: "Stays",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "AnimalStay",
                columns: table => new
                {
                    AnimalID = table.Column<int>(type: "int", nullable: false),
                    StayID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalStay", x => new { x.AnimalID, x.StayID });
                    table.ForeignKey(
                        name: "FK_AnimalStay_Animals_AnimalID",
                        column: x => x.AnimalID,
                        principalTable: "Animals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalStay_Stays_StayID",
                        column: x => x.StayID,
                        principalTable: "Stays",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "ID", "Age", "AnimalType", "Birthdate", "Castrated", "ChildFriendly", "DateOfDeath", "Description", "EstimatedAge", "Gender", "Name", "Picture", "Race", "ReasonGivenAway" },
                values: new object[] { 1, 1, 0, new DateTime(2020, 10, 6, 15, 19, 13, 159, DateTimeKind.Local).AddTicks(2209), true, 0, null, "Good boi", 1, " ", "Doggo", "Goodboi.png", "Best Bois", "Too good a boi" });

            migrationBuilder.UpdateData(
                table: "Lodgings",
                keyColumn: "ID",
                keyValue: 1,
                column: "MaxCapacity",
                value: 20);

            migrationBuilder.InsertData(
                table: "Stays",
                columns: new[] { "ID", "AdoptedBy", "AdoptionDate", "ArrivalDate", "CanBeAdopted", "LodgingLocationID" },
                values: new object[] { 1, "Barry", new DateTime(2020, 10, 6, 15, 19, 13, 158, DateTimeKind.Local).AddTicks(6317), new DateTime(2020, 10, 6, 15, 19, 13, 155, DateTimeKind.Local).AddTicks(3358), true, 1 });

            migrationBuilder.InsertData(
                table: "AnimalStay",
                columns: new[] { "AnimalID", "StayID" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "ID", "Content", "Date", "WrittenBy" },
                values: new object[] { 1, "Best boi", new DateTime(2020, 10, 6, 15, 19, 13, 160, DateTimeKind.Local).AddTicks(1514), "Dr. Barry" });

            migrationBuilder.InsertData(
                table: "Treatments",
                columns: new[] { "ID", "Costs", "Date", "Description", "DoneBy", "RequiredAge", "StayID", "TreatmentType" },
                values: new object[] { 1, 100.50m, new DateTime(2020, 10, 6, 15, 19, 13, 159, DateTimeKind.Local).AddTicks(9648), "Inenting voor ziekte x", "Some Person", 1, 1, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalStay_StayID",
                table: "AnimalStay",
                column: "StayID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Stays_ID",
                table: "Comments",
                column: "ID",
                principalTable: "Stays",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
