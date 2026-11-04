using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReportingDashboard.Migrations
{
    /// <inheritdoc />
    public partial class ReportingSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpenseRecords",
                columns: table => new
                {
                    ExpenseRecordId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Month = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Department = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseRecords", x => x.ExpenseRecordId);
                });

            migrationBuilder.CreateTable(
                name: "ReportRoles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportRoles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportId);
                });

            migrationBuilder.CreateTable(
                name: "SalesRecords",
                columns: table => new
                {
                    SalesRecordId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Month = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Region = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesRecords", x => x.SalesRecordId);
                });

            migrationBuilder.CreateTable(
                name: "ReportUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportUsers", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_ReportUsers_ReportRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ReportRoles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportPermissions",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false),
                    ReportId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportPermissions", x => new { x.RoleId, x.ReportId });
                    table.ForeignKey(
                        name: "FK_ReportPermissions_ReportRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ReportRoles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportPermissions_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ExpenseRecords",
                columns: new[] { "ExpenseRecordId", "Amount", "Department", "Month" },
                values: new object[,]
                {
                    { 1, 8000m, "Sales", new DateOnly(2026, 1, 1) },
                    { 2, 11000m, "Operations", new DateOnly(2026, 1, 1) },
                    { 3, 14000m, "IT", new DateOnly(2026, 1, 1) },
                    { 4, 17000m, "HR", new DateOnly(2026, 1, 1) },
                    { 5, 8500m, "Sales", new DateOnly(2026, 2, 1) },
                    { 6, 11500m, "Operations", new DateOnly(2026, 2, 1) },
                    { 7, 14500m, "IT", new DateOnly(2026, 2, 1) },
                    { 8, 17500m, "HR", new DateOnly(2026, 2, 1) },
                    { 9, 9000m, "Sales", new DateOnly(2026, 3, 1) },
                    { 10, 12000m, "Operations", new DateOnly(2026, 3, 1) },
                    { 11, 15000m, "IT", new DateOnly(2026, 3, 1) },
                    { 12, 18000m, "HR", new DateOnly(2026, 3, 1) },
                    { 13, 8000m, "Sales", new DateOnly(2026, 4, 1) },
                    { 14, 11000m, "Operations", new DateOnly(2026, 4, 1) },
                    { 15, 14000m, "IT", new DateOnly(2026, 4, 1) },
                    { 16, 17000m, "HR", new DateOnly(2026, 4, 1) },
                    { 17, 8500m, "Sales", new DateOnly(2026, 5, 1) },
                    { 18, 11500m, "Operations", new DateOnly(2026, 5, 1) },
                    { 19, 14500m, "IT", new DateOnly(2026, 5, 1) },
                    { 20, 17500m, "HR", new DateOnly(2026, 5, 1) },
                    { 21, 9000m, "Sales", new DateOnly(2026, 6, 1) },
                    { 22, 12000m, "Operations", new DateOnly(2026, 6, 1) },
                    { 23, 15000m, "IT", new DateOnly(2026, 6, 1) },
                    { 24, 18000m, "HR", new DateOnly(2026, 6, 1) },
                    { 25, 8000m, "Sales", new DateOnly(2026, 7, 1) },
                    { 26, 11000m, "Operations", new DateOnly(2026, 7, 1) },
                    { 27, 14000m, "IT", new DateOnly(2026, 7, 1) },
                    { 28, 17000m, "HR", new DateOnly(2026, 7, 1) },
                    { 29, 8500m, "Sales", new DateOnly(2026, 8, 1) },
                    { 30, 11500m, "Operations", new DateOnly(2026, 8, 1) },
                    { 31, 14500m, "IT", new DateOnly(2026, 8, 1) },
                    { 32, 17500m, "HR", new DateOnly(2026, 8, 1) },
                    { 33, 9000m, "Sales", new DateOnly(2026, 9, 1) },
                    { 34, 12000m, "Operations", new DateOnly(2026, 9, 1) },
                    { 35, 15000m, "IT", new DateOnly(2026, 9, 1) },
                    { 36, 18000m, "HR", new DateOnly(2026, 9, 1) },
                    { 37, 8000m, "Sales", new DateOnly(2026, 10, 1) },
                    { 38, 11000m, "Operations", new DateOnly(2026, 10, 1) },
                    { 39, 14000m, "IT", new DateOnly(2026, 10, 1) },
                    { 40, 17000m, "HR", new DateOnly(2026, 10, 1) },
                    { 41, 8500m, "Sales", new DateOnly(2026, 11, 1) },
                    { 42, 11500m, "Operations", new DateOnly(2026, 11, 1) },
                    { 43, 14500m, "IT", new DateOnly(2026, 11, 1) },
                    { 44, 17500m, "HR", new DateOnly(2026, 11, 1) },
                    { 45, 9000m, "Sales", new DateOnly(2026, 12, 1) },
                    { 46, 12000m, "Operations", new DateOnly(2026, 12, 1) },
                    { 47, 15000m, "IT", new DateOnly(2026, 12, 1) },
                    { 48, 18000m, "HR", new DateOnly(2026, 12, 1) }
                });

            migrationBuilder.InsertData(
                table: "ReportRoles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { 1, "Employee" },
                    { 2, "Manager" },
                    { 3, "Executive" }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "ReportId", "Category", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Sales", "Monthly sales total by region.", "Regional Sales" },
                    { 2, "Finance", "Monthly expenses by department.", "Department Expenses" },
                    { 3, "Executive", "Company-wide sales compared to expenses.", "Profit Overview" }
                });

            migrationBuilder.InsertData(
                table: "SalesRecords",
                columns: new[] { "SalesRecordId", "Amount", "Month", "Region" },
                values: new object[,]
                {
                    { 1, 20000m, new DateOnly(2026, 1, 1), "North" },
                    { 2, 25000m, new DateOnly(2026, 1, 1), "South" },
                    { 3, 30000m, new DateOnly(2026, 1, 1), "East" },
                    { 4, 35000m, new DateOnly(2026, 1, 1), "West" },
                    { 5, 20750m, new DateOnly(2026, 2, 1), "North" },
                    { 6, 25750m, new DateOnly(2026, 2, 1), "South" },
                    { 7, 30750m, new DateOnly(2026, 2, 1), "East" },
                    { 8, 35750m, new DateOnly(2026, 2, 1), "West" },
                    { 9, 21500m, new DateOnly(2026, 3, 1), "North" },
                    { 10, 26500m, new DateOnly(2026, 3, 1), "South" },
                    { 11, 31500m, new DateOnly(2026, 3, 1), "East" },
                    { 12, 36500m, new DateOnly(2026, 3, 1), "West" },
                    { 13, 22250m, new DateOnly(2026, 4, 1), "North" },
                    { 14, 27250m, new DateOnly(2026, 4, 1), "South" },
                    { 15, 32250m, new DateOnly(2026, 4, 1), "East" },
                    { 16, 37250m, new DateOnly(2026, 4, 1), "West" },
                    { 17, 23000m, new DateOnly(2026, 5, 1), "North" },
                    { 18, 28000m, new DateOnly(2026, 5, 1), "South" },
                    { 19, 33000m, new DateOnly(2026, 5, 1), "East" },
                    { 20, 38000m, new DateOnly(2026, 5, 1), "West" },
                    { 21, 23750m, new DateOnly(2026, 6, 1), "North" },
                    { 22, 28750m, new DateOnly(2026, 6, 1), "South" },
                    { 23, 33750m, new DateOnly(2026, 6, 1), "East" },
                    { 24, 38750m, new DateOnly(2026, 6, 1), "West" },
                    { 25, 24500m, new DateOnly(2026, 7, 1), "North" },
                    { 26, 29500m, new DateOnly(2026, 7, 1), "South" },
                    { 27, 34500m, new DateOnly(2026, 7, 1), "East" },
                    { 28, 39500m, new DateOnly(2026, 7, 1), "West" },
                    { 29, 25250m, new DateOnly(2026, 8, 1), "North" },
                    { 30, 30250m, new DateOnly(2026, 8, 1), "South" },
                    { 31, 35250m, new DateOnly(2026, 8, 1), "East" },
                    { 32, 40250m, new DateOnly(2026, 8, 1), "West" },
                    { 33, 26000m, new DateOnly(2026, 9, 1), "North" },
                    { 34, 31000m, new DateOnly(2026, 9, 1), "South" },
                    { 35, 36000m, new DateOnly(2026, 9, 1), "East" },
                    { 36, 41000m, new DateOnly(2026, 9, 1), "West" },
                    { 37, 26750m, new DateOnly(2026, 10, 1), "North" },
                    { 38, 31750m, new DateOnly(2026, 10, 1), "South" },
                    { 39, 36750m, new DateOnly(2026, 10, 1), "East" },
                    { 40, 41750m, new DateOnly(2026, 10, 1), "West" },
                    { 41, 27500m, new DateOnly(2026, 11, 1), "North" },
                    { 42, 32500m, new DateOnly(2026, 11, 1), "South" },
                    { 43, 37500m, new DateOnly(2026, 11, 1), "East" },
                    { 44, 42500m, new DateOnly(2026, 11, 1), "West" },
                    { 45, 28250m, new DateOnly(2026, 12, 1), "North" },
                    { 46, 33250m, new DateOnly(2026, 12, 1), "South" },
                    { 47, 38250m, new DateOnly(2026, 12, 1), "East" },
                    { 48, 43250m, new DateOnly(2026, 12, 1), "West" }
                });

            migrationBuilder.InsertData(
                table: "ReportPermissions",
                columns: new[] { "ReportId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "ReportUsers",
                columns: new[] { "UserId", "Name", "RoleId" },
                values: new object[,]
                {
                    { 1, "Jordan Lee", 1 },
                    { 2, "Sam Patel", 1 },
                    { 3, "Taylor Brooks", 2 },
                    { 4, "Morgan Reyes", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportPermissions_ReportId",
                table: "ReportPermissions",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportUsers_RoleId",
                table: "ReportUsers",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenseRecords");

            migrationBuilder.DropTable(
                name: "ReportPermissions");

            migrationBuilder.DropTable(
                name: "ReportUsers");

            migrationBuilder.DropTable(
                name: "SalesRecords");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "ReportRoles");
        }
    }
}
