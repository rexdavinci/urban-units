using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fractionalized.Migrations
{
    /// <inheritdoc />
    public partial class SubscriberUsername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Subscribers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Subscribers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Subscribers");
        }
    }
}
