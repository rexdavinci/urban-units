using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fractionalized.Migrations
{
    /// <inheritdoc />
    public partial class AddUnitsSold : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvailableUnits",
                table: "Buildings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SoldUnits",
                table: "Buildings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableUnits",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "SoldUnits",
                table: "Buildings");
        }
    }
}
