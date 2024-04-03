using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonthlyStatements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Month = table.Column<DateOnly>(type: "date", nullable: false),
                    Createrd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyStatements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Finances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinanceType = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MonthlyStatementId = table.Column<int>(type: "int", nullable: true),
                    Createrd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Finances_MonthlyStatements_MonthlyStatementId",
                        column: x => x.MonthlyStatementId,
                        principalTable: "MonthlyStatements",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Finances",
                columns: new[] { "Id", "Amount", "Createrd", "FinanceType", "MonthlyStatementId", "Title", "Updated" },
                values: new object[,]
                {
                    { 1, -100.00m, new DateTime(2024, 4, 3, 22, 23, 48, 500, DateTimeKind.Local).AddTicks(5292), 2, null, "Biedronka", null },
                    { 2, 1000.00m, new DateTime(2024, 4, 3, 20, 23, 48, 500, DateTimeKind.Utc).AddTicks(5296), 1, null, "Wypłata", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Finances_MonthlyStatementId",
                table: "Finances",
                column: "MonthlyStatementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Finances");

            migrationBuilder.DropTable(
                name: "MonthlyStatements");
        }
    }
}
