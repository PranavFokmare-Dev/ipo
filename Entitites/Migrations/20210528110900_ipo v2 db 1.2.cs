using Microsoft.EntityFrameworkCore.Migrations;

namespace ipo.Migrations
{
    public partial class ipov2db12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilterSubscriptions_Users_FilterSubscriptionId",
                table: "FilterSubscriptions");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FilterSubscriptionId",
                table: "Users",
                column: "FilterSubscriptionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_FilterSubscriptions_FilterSubscriptionId",
                table: "Users",
                column: "FilterSubscriptionId",
                principalTable: "FilterSubscriptions",
                principalColumn: "FilterSubscriptionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_FilterSubscriptions_FilterSubscriptionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_FilterSubscriptionId",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_FilterSubscriptions_Users_FilterSubscriptionId",
                table: "FilterSubscriptions",
                column: "FilterSubscriptionId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
