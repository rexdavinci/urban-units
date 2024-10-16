using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fractionalized.Migrations
{
    /// <inheritdoc />
    public partial class capitalizeBuildingunitField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingUnits_Buildings_buildingId",
                table: "BuildingUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_BuildingUnits_Subscribers_subscriberId",
                table: "BuildingUnits");

            migrationBuilder.RenameColumn(
                name: "subscriberId",
                table: "BuildingUnits",
                newName: "SubscriberId");

            migrationBuilder.RenameColumn(
                name: "buildingId",
                table: "BuildingUnits",
                newName: "BuildingId");

            migrationBuilder.RenameIndex(
                name: "IX_BuildingUnits_subscriberId",
                table: "BuildingUnits",
                newName: "IX_BuildingUnits_SubscriberId");

            migrationBuilder.RenameIndex(
                name: "IX_BuildingUnits_buildingId",
                table: "BuildingUnits",
                newName: "IX_BuildingUnits_BuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingUnits_Buildings_BuildingId",
                table: "BuildingUnits",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingUnits_Subscribers_SubscriberId",
                table: "BuildingUnits",
                column: "SubscriberId",
                principalTable: "Subscribers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingUnits_Buildings_BuildingId",
                table: "BuildingUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_BuildingUnits_Subscribers_SubscriberId",
                table: "BuildingUnits");

            migrationBuilder.RenameColumn(
                name: "SubscriberId",
                table: "BuildingUnits",
                newName: "subscriberId");

            migrationBuilder.RenameColumn(
                name: "BuildingId",
                table: "BuildingUnits",
                newName: "buildingId");

            migrationBuilder.RenameIndex(
                name: "IX_BuildingUnits_SubscriberId",
                table: "BuildingUnits",
                newName: "IX_BuildingUnits_subscriberId");

            migrationBuilder.RenameIndex(
                name: "IX_BuildingUnits_BuildingId",
                table: "BuildingUnits",
                newName: "IX_BuildingUnits_buildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingUnits_Buildings_buildingId",
                table: "BuildingUnits",
                column: "buildingId",
                principalTable: "Buildings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingUnits_Subscribers_subscriberId",
                table: "BuildingUnits",
                column: "subscriberId",
                principalTable: "Subscribers",
                principalColumn: "Id");
        }
    }
}
