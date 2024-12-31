using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class fixbugTableComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ReplyCommentId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ReplyCommentId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "TotalReply",
                table: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalReply",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ReplyCommentId",
                table: "Comments",
                column: "ReplyCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ReplyCommentId",
                table: "Comments",
                column: "ReplyCommentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }
    }
}
