using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace socialpostanalyzer.Migrations
{
    /// <inheritdoc />
    public partial class deleteidfromPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Post_postId",
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "postId",
                table: "Comment",
                newName: "PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_postId",
                table: "Comment",
                newName: "IX_Comment_PostId");

            migrationBuilder.AddColumn<string>(
                name: "PostId1",
                table: "Shares",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostId1",
                table: "Reaction",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PostId",
                table: "Post",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PostId",
                table: "Comment",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                table: "Post",
                column: "PostId");

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
                principalColumn: "PostId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "PostId1",
                table: "Shares");

            migrationBuilder.DropColumn(
                name: "PostId1",
                table: "Reaction");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Comment",
                newName: "postId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_PostId",
                table: "Comment",
                newName: "IX_Comment_postId");

            migrationBuilder.AlterColumn<string>(
                name: "PostId",
                table: "Post",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "postId",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                table: "Post",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Shares_PostId",
                table: "Shares",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Reaction_PostId",
                table: "Reaction",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Post_postId",
                table: "Comment",
                column: "postId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reaction_Post_PostId",
                table: "Reaction",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shares_Post_PostId",
                table: "Shares",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
