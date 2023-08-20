using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace socialpostanalyzer.Migrations
{
    /// <inheritdoc />
    public partial class addreactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AngryNum",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HahaNum",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LoveNum",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SadNum",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WowNum",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AngryNum",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "HahaNum",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "LoveNum",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "SadNum",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "WowNum",
                table: "Post");
        }
    }
}
