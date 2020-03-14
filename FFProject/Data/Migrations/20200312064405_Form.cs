using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FFProject.Data.Migrations
{
    public partial class Form : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamModelID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageText = table.Column<string>(maxLength: 1000, nullable: false),
                    MessengerId = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageID);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_MessengerId",
                        column: x => x.MessengerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamModelID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamModelID);
                });

            migrationBuilder.CreateTable(
                name: "Trades",
                columns: table => new
                {
                    TradeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trades", x => x.TradeID);
                });

            migrationBuilder.CreateTable(
                name: "Rosters",
                columns: table => new
                {
                    RosterID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerName = table.Column<string>(nullable: true),
                    PlayerPosition = table.Column<string>(nullable: true),
                    PlayerValue = table.Column<int>(nullable: false),
                    TradeOffersTradeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rosters", x => x.RosterID);
                    table.ForeignKey(
                        name: "FK_Rosters_Trades_TradeOffersTradeID",
                        column: x => x.TradeOffersTradeID,
                        principalTable: "Trades",
                        principalColumn: "TradeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TeamModelID",
                table: "AspNetUsers",
                column: "TeamModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessengerId",
                table: "Messages",
                column: "MessengerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rosters_TradeOffersTradeID",
                table: "Rosters",
                column: "TradeOffersTradeID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Teams_TeamModelID",
                table: "AspNetUsers",
                column: "TeamModelID",
                principalTable: "Teams",
                principalColumn: "TeamModelID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Teams_TeamModelID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Rosters");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Trades");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TeamModelID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TeamModelID",
                table: "AspNetUsers");
        }
    }
}
