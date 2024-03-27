using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace socialpostanalyzer.Migrations
{
    /// <inheritdoc />
    public partial class comment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Reaction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reaction_CommentId",
                table: "Reaction",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reaction_Comment_CommentId",
                table: "Reaction",
                column: "CommentId",
                principalTable: "Comment",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reaction_Comment_CommentId",
                table: "Reaction");

            migrationBuilder.DropIndex(
                name: "IX_Reaction_CommentId",
                table: "Reaction");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Reaction");
        }
    }
}
