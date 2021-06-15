using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ipo.Migrations
{
    public partial class ipov2db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exchanges",
                columns: table => new
                {
                    ExchangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExchangeName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exchanges", x => x.ExchangeId);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    SubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QualifiedInstitutional = table.Column<float>(type: "real", nullable: false),
                    NonInstitutional = table.Column<float>(type: "real", nullable: false),
                    RetailIndividual = table.Column<float>(type: "real", nullable: false),
                    Employee = table.Column<float>(type: "real", nullable: false),
                    Others = table.Column<float>(type: "real", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    IPOId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.SubscriptionId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FilterSubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "IPOs",
                columns: table => new
                {
                    IPOId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Open = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Close = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LotSize = table.Column<int>(type: "int", nullable: true),
                    IssuePriceRs = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IssueSizeRsCr = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPOs", x => x.IPOId);
                    table.ForeignKey(
                        name: "FK_IPOs_Subscriptions_IPOId",
                        column: x => x.IPOId,
                        principalTable: "Subscriptions",
                        principalColumn: "SubscriptionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilterSubscriptions",
                columns: table => new
                {
                    FilterSubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MinQualifiedInstitutional = table.Column<float>(type: "real", nullable: false),
                    MinNonInstitutional = table.Column<float>(type: "real", nullable: false),
                    MinRetailIndividual = table.Column<float>(type: "real", nullable: false),
                    MinEmployee = table.Column<float>(type: "real", nullable: false),
                    MinOthers = table.Column<float>(type: "real", nullable: false),
                    MinTotal = table.Column<float>(type: "real", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilterSubscriptions", x => x.FilterSubscriptionId);
                    table.ForeignKey(
                        name: "FK_FilterSubscriptions_Users_FilterSubscriptionId",
                        column: x => x.FilterSubscriptionId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IPOExchanges",
                columns: table => new
                {
                    IPOId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExchangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPOExchanges", x => new { x.IPOId, x.ExchangeId });
                    table.ForeignKey(
                        name: "FK_IPOExchanges_Exchanges_ExchangeId",
                        column: x => x.ExchangeId,
                        principalTable: "Exchanges",
                        principalColumn: "ExchangeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IPOExchanges_IPOs_IPOId",
                        column: x => x.IPOId,
                        principalTable: "IPOs",
                        principalColumn: "IPOId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IPOExchanges_ExchangeId",
                table: "IPOExchanges",
                column: "ExchangeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilterSubscriptions");

            migrationBuilder.DropTable(
                name: "IPOExchanges");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Exchanges");

            migrationBuilder.DropTable(
                name: "IPOs");

            migrationBuilder.DropTable(
                name: "Subscriptions");
        }
    }
}
