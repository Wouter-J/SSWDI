using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AS_EFShelterData.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lodgings",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LodgingType = table.Column<int>(nullable: false),
                    MaxCapacity = table.Column<int>(nullable: false),
                    AnimalType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lodgings", x => x.ID);
                });

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
                    DateOfDeath = table.Column<DateTime>(nullable: false),
                    Castrated = table.Column<bool>(nullable: false),
                    ChildFriendly = table.Column<int>(nullable: false),
                    ReasonGivenAway = table.Column<string>(nullable: true),
                    LodgingID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Animals_Lodgings_LodgingID",
                        column: x => x.LodgingID,
                        principalTable: "Lodgings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stays",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalID = table.Column<int>(nullable: true),
                    ArrivalDate = table.Column<DateTime>(nullable: false),
                    AdoptionDate = table.Column<DateTime>(nullable: false),
                    CanBeAdopted = table.Column<bool>(nullable: false),
                    AdoptedBy = table.Column<string>(nullable: true),
                    LodgingLocationID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stays", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Stays_Animals_AnimalID",
                        column: x => x.AnimalID,
                        principalTable: "Animals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stays_Lodgings_LodgingLocationID",
                        column: x => x.LodgingLocationID,
                        principalTable: "Lodgings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    WrittenBy = table.Column<string>(nullable: true),
                    StayID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comments_Stays_StayID",
                        column: x => x.StayID,
                        principalTable: "Stays",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
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
                    StayID = table.Column<int>(nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Animals_LodgingID",
                table: "Animals",
                column: "LodgingID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_StayID",
                table: "Comments",
                column: "StayID");

            migrationBuilder.CreateIndex(
                name: "IX_Stays_AnimalID",
                table: "Stays",
                column: "AnimalID");

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
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Treatments");

            migrationBuilder.DropTable(
                name: "Stays");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Lodgings");
        }
    }
}
