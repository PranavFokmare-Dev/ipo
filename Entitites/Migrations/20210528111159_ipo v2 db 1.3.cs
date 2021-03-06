using Microsoft.EntityFrameworkCore.Migrations;

namespace ipo.Migrations
{
    public partial class ipov2db13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_IPOs_IPOId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_IPOId",
                table: "Subscriptions");

            migrationBuilder.CreateIndex(
                name: "IX_IPOs_SubscriptionId",
                table: "IPOs",
                column: "SubscriptionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IPOs_Subscriptions_SubscriptionId",
                table: "IPOs",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "SubscriptionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IPOs_Subscriptions_SubscriptionId",
                table: "IPOs");

            migrationBuilder.DropIndex(
                name: "IX_IPOs_SubscriptionId",
                table: "IPOs");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_IPOId",
                table: "Subscriptions",
                column: "IPOId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_IPOs_IPOId",
                table: "Subscriptions",
                column: "IPOId",
                principalTable: "IPOs",
                principalColumn: "IPOId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
