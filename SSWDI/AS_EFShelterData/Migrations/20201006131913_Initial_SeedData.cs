﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AS_EFShelterData.Migrations
{
    public partial class Initial_SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    EstimatedAge = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    AnimalType = table.Column<int>(nullable: false),
                    Race = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: false),
                    Picture = table.Column<string>(nullable: true),
                    DateOfDeath = table.Column<DateTime>(nullable: true),
                    Castrated = table.Column<bool>(nullable: false),
                    ChildFriendly = table.Column<int>(nullable: false),
                    ReasonGivenAway = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Lodgings",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LodgingType = table.Column<int>(nullable: false),
                    MaxCapacity = table.Column<int>(nullable: false),
                    AnimalType = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lodgings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Stays",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArrivalDate = table.Column<DateTime>(nullable: false),
                    AdoptionDate = table.Column<DateTime>(nullable: false),
                    CanBeAdopted = table.Column<bool>(nullable: false),
                    AdoptedBy = table.Column<string>(nullable: true),
                    LodgingLocationID = table.Column<int>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stays", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Stays_Lodgings_LodgingLocationID",
                        column: x => x.LodgingLocationID,
                        principalTable: "Lodgings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnimalStay",
                columns: table => new
                {
                    AnimalID = table.Column<int>(nullable: false),
                    StayID = table.Column<int>(nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    WrittenBy = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comments_Stays_ID",
                        column: x => x.ID,
                        principalTable: "Stays",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Treatments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    TreatmentType = table.Column<int>(nullable: false),
                    Costs = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    RequiredAge = table.Column<int>(nullable: false),
                    DoneBy = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    StayID = table.Column<int>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Treatments_Stays_StayID",
                        column: x => x.StayID,
                        principalTable: "Stays",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "ID", "Age", "AnimalType", "Birthdate", "Castrated", "ChildFriendly", "DateOfDeath", "Description", "EstimatedAge", "Gender", "Name", "Picture", "Race", "ReasonGivenAway" },
                values: new object[] { 1, 1, 0, new DateTime(2020, 10, 6, 15, 19, 13, 159, DateTimeKind.Local).AddTicks(2209), true, 0, null, "Good boi", 1, " ", "Doggo", "Goodboi.png", "Best Bois", "Too good a boi" });

            migrationBuilder.InsertData(
                table: "Lodgings",
                columns: new[] { "ID", "AnimalType", "LodgingType", "MaxCapacity" },
                values: new object[] { 1, 0, 0, 20 });

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

            migrationBuilder.CreateIndex(
                name: "IX_Stays_LodgingLocationID",
                table: "Stays",
                column: "LodgingLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_StayID",
                table: "Treatments",
                column: "StayID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalStay");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Treatments");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Stays");

            migrationBuilder.DropTable(
                name: "Lodgings");
        }
    }
}
