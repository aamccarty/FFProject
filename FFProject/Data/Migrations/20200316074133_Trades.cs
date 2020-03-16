using Microsoft.EntityFrameworkCore.Migrations;

namespace FFProject.Data.Migrations
{
    public partial class Trades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rosters_Trades_TradeOffersTradeID",
                table: "Rosters");

            migrationBuilder.DropIndex(
                name: "IX_Rosters_TradeOffersTradeID",
                table: "Rosters");

            migrationBuilder.DropColumn(
                name: "TradeOffersTradeID",
                table: "Rosters");

            migrationBuilder.AddColumn<int>(
                name: "TradeOfferTradeID",
                table: "Trades",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trades_TradeOfferTradeID",
                table: "Trades",
                column: "TradeOfferTradeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Trades_Trades_TradeOfferTradeID",
                table: "Trades",
                column: "TradeOfferTradeID",
                principalTable: "Trades",
                principalColumn: "TradeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trades_Trades_TradeOfferTradeID",
                table: "Trades");

            migrationBuilder.DropIndex(
                name: "IX_Trades_TradeOfferTradeID",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "TradeOfferTradeID",
                table: "Trades");

            migrationBuilder.AddColumn<int>(
                name: "TradeOffersTradeID",
                table: "Rosters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rosters_TradeOffersTradeID",
                table: "Rosters",
                column: "TradeOffersTradeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rosters_Trades_TradeOffersTradeID",
                table: "Rosters",
                column: "TradeOffersTradeID",
                principalTable: "Trades",
                principalColumn: "TradeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
