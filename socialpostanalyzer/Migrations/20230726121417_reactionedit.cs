using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace socialpostanalyzer.Migrations
{
    /// <inheritdoc />
    public partial class reactionedit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Post_PostId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Reaction_Post_PostId1",
                table: "Reaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Shares_Post_PostId1",
                table: "Shares");

            migrationBuilder.DropIndex(
                name: "IX_Shares_PostId1",
                table: "Shares");

            migrationBuilder.DropIndex(
                name: "IX_Reaction_PostId1",
                table: "Reaction");

            migrationBuilder.DropColumn(
                name: "PostId1",
                table: "Shares");

            migrationBuilder.DropColumn(
                name: "PostId1",
                table: "Reaction");

            migrationBuilder.AlterColumn<string>(
                name: "PostId",
                table: "Shares",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PostId",
                table: "Reaction",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ReactionNum",
                table: "Reaction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PostId",
                table: "Comment",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Shares_PostId",
                table: "Shares",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Reaction_PostId",
                table: "Reaction",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Post_PostId",
                table: "Comment",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reaction_Post_PostId",
                table: "Reaction",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shares_Post_PostId",
                table: "Shares",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Post_PostId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Reaction_Post_PostId",
                table: "Reaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Shares_Post_PostId",
                table: "Shares");

            migrationBuilder.DropIndex(
                name: "IX_Shares_PostId",
                table: "Shares");

            migrationBuilder.DropIndex(
                name: "IX_Reaction_PostId",
                table: "Reaction");

            migrationBuilder.DropColumn(
                name: "ReactionNum",
                table: "Reaction");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "Shares",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "PostId1",
                table: "Shares",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "Reaction",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "PostId1",
                table: "Reaction",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PostId",
                table: "Comment",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shares_PostId1",
                table: "Shares",
                column: "PostId1");

            migrationBuilder.CreateIndex(
                name: "IX_Reaction_PostId1",
                table: "Reaction",
                column: "PostId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Post_PostId",
                table: "Comment",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reaction_Post_PostId1",
                table: "Reaction",
                column: "PostId1",
                principalTable: "Post",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shares_Post_PostId1",
                table: "Shares",
                column: "PostId1",
                principalTable: "Post",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
