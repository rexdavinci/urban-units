using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fractionalized.Migrations
{
    /// <inheritdoc />
    public partial class Valuation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CurrentValuation",
                table: "Buildings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastValuedAt",
                table: "Buildings",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentValuation",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "LastValuedAt",
                table: "Buildings");
        }
    }
}
