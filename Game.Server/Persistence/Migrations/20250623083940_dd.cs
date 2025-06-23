using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class dd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Markers");

            migrationBuilder.DropColumn(
                name: "Rotation",
                table: "Markers");

            migrationBuilder.DropColumn(
                name: "Scale",
                table: "Markers");

            migrationBuilder.AddColumn<float>(
                name: "PositionX",
                table: "Markers",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PositionY",
                table: "Markers",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PositionZ",
                table: "Markers",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "RotationW",
                table: "Markers",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "RotationX",
                table: "Markers",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "RotationY",
                table: "Markers",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "RotationZ",
                table: "Markers",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ScaleX",
                table: "Markers",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ScaleY",
                table: "Markers",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ScaleZ",
                table: "Markers",
                type: "float",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PositionX",
                table: "Markers");

            migrationBuilder.DropColumn(
                name: "PositionY",
                table: "Markers");

            migrationBuilder.DropColumn(
                name: "PositionZ",
                table: "Markers");

            migrationBuilder.DropColumn(
                name: "RotationW",
                table: "Markers");

            migrationBuilder.DropColumn(
                name: "RotationX",
                table: "Markers");

            migrationBuilder.DropColumn(
                name: "RotationY",
                table: "Markers");

            migrationBuilder.DropColumn(
                name: "RotationZ",
                table: "Markers");

            migrationBuilder.DropColumn(
                name: "ScaleX",
                table: "Markers");

            migrationBuilder.DropColumn(
                name: "ScaleY",
                table: "Markers");

            migrationBuilder.DropColumn(
                name: "ScaleZ",
                table: "Markers");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Markers",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rotation",
                table: "Markers",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Scale",
                table: "Markers",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");
        }
    }
}
