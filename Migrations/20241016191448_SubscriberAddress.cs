using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fractionalized.Migrations
{
    /// <inheritdoc />
    public partial class SubscriberAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CryptoAddress",
                table: "Subscribers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Spent",
                table: "Subscribers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CryptoAddress",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "Spent",
                table: "Subscribers");
        }
    }
}
