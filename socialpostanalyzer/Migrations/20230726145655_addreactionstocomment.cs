using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace socialpostanalyzer.Migrations
{
    /// <inheritdoc />
    public partial class addreactionstocomment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReactionName",
                table: "Reaction");

            migrationBuilder.RenameColumn(
                name: "ReactionNum",
                table: "Reaction",
                newName: "Wow");

            migrationBuilder.AddColumn<int>(
                name: "Angry",
                table: "Reaction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Haha",
                table: "Reaction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Like",
                table: "Reaction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Love",
                table: "Reaction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sad",
                table: "Reaction",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Angry",
                table: "Reaction");

            migrationBuilder.DropColumn(
                name: "Haha",
                table: "Reaction");

            migrationBuilder.DropColumn(
                name: "Like",
                table: "Reaction");

            migrationBuilder.DropColumn(
                name: "Love",
                table: "Reaction");

            migrationBuilder.DropColumn(
                name: "Sad",
                table: "Reaction");

            migrationBuilder.RenameColumn(
                name: "Wow",
                table: "Reaction",
                newName: "ReactionNum");

            migrationBuilder.AddColumn<string>(
                name: "ReactionName",
                table: "Reaction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
