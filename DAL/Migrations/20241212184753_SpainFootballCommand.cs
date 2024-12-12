using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class SpainFootballCommand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "CopiesSold",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Mode",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Teams",
                newName: "TeamName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Teams",
                newName: "City");

            migrationBuilder.AddColumn<int>(
                name: "Draws",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoalsConceded",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoalsScored",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Losses",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Wins",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Draws",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "GoalsConceded",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "GoalsScored",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Losses",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Wins",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "TeamName",
                table: "Teams",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Teams",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CopiesSold",
                table: "Teams",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mode",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
