using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ipo.Migrations
{
    public partial class ipov214 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IPOExchanges",
                table: "IPOExchanges");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "IPOExchanges",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_IPOExchanges",
                table: "IPOExchanges",
                columns: new[] { "Id", "IPOId", "ExchangeId" });

            migrationBuilder.CreateIndex(
                name: "IX_IPOExchanges_IPOId",
                table: "IPOExchanges",
                column: "IPOId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IPOExchanges",
                table: "IPOExchanges");

            migrationBuilder.DropIndex(
                name: "IX_IPOExchanges_IPOId",
                table: "IPOExchanges");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "IPOExchanges");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IPOExchanges",
                table: "IPOExchanges",
                columns: new[] { "IPOId", "ExchangeId" });
        }
    }
}
