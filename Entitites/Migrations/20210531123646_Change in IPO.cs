using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ipo.Migrations
{
    public partial class ChangeinIPO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IPOs_Subscriptions_SubscriptionId",
                table: "IPOs");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_FilterSubscriptions_FilterSubscriptionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_FilterSubscriptionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_IPOs_SubscriptionId",
                table: "IPOs");

            migrationBuilder.AlterColumn<Guid>(
                name: "FilterSubscriptionId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubscriptionId",
                table: "IPOs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "IPOs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_FilterSubscriptionId",
                table: "Users",
                column: "FilterSubscriptionId",
                unique: true,
                filter: "[FilterSubscriptionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_IPOs_SubscriptionId",
                table: "IPOs",
                column: "SubscriptionId",
                unique: true,
                filter: "[SubscriptionId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_IPOs_Subscriptions_SubscriptionId",
                table: "IPOs",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "SubscriptionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_FilterSubscriptions_FilterSubscriptionId",
                table: "Users",
                column: "FilterSubscriptionId",
                principalTable: "FilterSubscriptions",
                principalColumn: "FilterSubscriptionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IPOs_Subscriptions_SubscriptionId",
                table: "IPOs");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_FilterSubscriptions_FilterSubscriptionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_FilterSubscriptionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_IPOs_SubscriptionId",
                table: "IPOs");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "IPOs");

            migrationBuilder.AlterColumn<Guid>(
                name: "FilterSubscriptionId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SubscriptionId",
                table: "IPOs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_FilterSubscriptionId",
                table: "Users",
                column: "FilterSubscriptionId",
                unique: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Users_FilterSubscriptions_FilterSubscriptionId",
                table: "Users",
                column: "FilterSubscriptionId",
                principalTable: "FilterSubscriptions",
                principalColumn: "FilterSubscriptionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
