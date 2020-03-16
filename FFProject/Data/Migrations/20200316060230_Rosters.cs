using Microsoft.EntityFrameworkCore.Migrations;

namespace FFProject.Data.Migrations
{
    public partial class Rosters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Rosters",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rosters_OwnerId",
                table: "Rosters",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rosters_AspNetUsers_OwnerId",
                table: "Rosters",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rosters_AspNetUsers_OwnerId",
                table: "Rosters");

            migrationBuilder.DropIndex(
                name: "IX_Rosters_OwnerId",
                table: "Rosters");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Rosters");
        }
    }
}
