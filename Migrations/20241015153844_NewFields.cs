using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fractionalized.Migrations
{
    /// <inheritdoc />
    public partial class NewFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FractionCost",
                table: "Buildings",
                newName: "UnitCost");

            migrationBuilder.AddColumn<string>(
                name: "BuildingType",
                table: "Buildings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExitDate",
                table: "Buildings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaximumPurchaseUnits",
                table: "Buildings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinimumPurchaseUnits",
                table: "Buildings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Buildings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildingType",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "ExitDate",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "MaximumPurchaseUnits",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "MinimumPurchaseUnits",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Buildings");

            migrationBuilder.RenameColumn(
                name: "UnitCost",
                table: "Buildings",
                newName: "FractionCost");
        }
    }
}
