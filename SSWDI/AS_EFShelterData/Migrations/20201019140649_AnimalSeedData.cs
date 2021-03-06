﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AS_EFShelterData.Migrations
{
    public partial class AnimalSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommentID",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Comments",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "ID");

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "ID", "Age", "AnimalType", "Birthdate", "Castrated", "ChildFriendly", "DateOfDeath", "Description", "EstimatedAge", "Gender", "Name", "Picture", "Race", "ReasonGivenAway" },
                values: new object[] { 1, 2, 0, new DateTime(2018, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0, null, "Good boi", 2, " ", "Doggo", "Goodboi.png", "Best Bois", "Too good a boi" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "ID", "Age", "AnimalType", "Birthdate", "Castrated", "ChildFriendly", "DateOfDeath", "Description", "EstimatedAge", "Gender", "Name", "Picture", "Race", "ReasonGivenAway" },
                values: new object[] { 2, 2, 1, new DateTime(2018, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0, null, "Good boi", 2, " ", "Garfield", "Garfield.png", "Garfields", "Ate too much lasagna" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "CommentID",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "CommentID");
        }
    }
}
