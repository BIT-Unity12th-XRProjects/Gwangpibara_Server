using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_missing_Property : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "rotation",
                table: "Markers",
                newName: "Rotation");

            migrationBuilder.RenameColumn(
                name: "removeStep",
                table: "Markers",
                newName: "RemoveStep");

            migrationBuilder.RenameColumn(
                name: "position",
                table: "Markers",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Markers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "dropItemID",
                table: "Markers",
                newName: "DropItemID");

            migrationBuilder.RenameColumn(
                name: "acquireStep",
                table: "Markers",
                newName: "AcquireStep");

            migrationBuilder.AddColumn<int>(
                name: "MarkerSpawnType",
                table: "Markers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MarkerType",
                table: "Markers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarkerSpawnType",
                table: "Markers");

            migrationBuilder.DropColumn(
                name: "MarkerType",
                table: "Markers");

            migrationBuilder.RenameColumn(
                name: "Rotation",
                table: "Markers",
                newName: "rotation");

            migrationBuilder.RenameColumn(
                name: "RemoveStep",
                table: "Markers",
                newName: "removeStep");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "Markers",
                newName: "position");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Markers",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "DropItemID",
                table: "Markers",
                newName: "dropItemID");

            migrationBuilder.RenameColumn(
                name: "AcquireStep",
                table: "Markers",
                newName: "acquireStep");
        }
    }
}
