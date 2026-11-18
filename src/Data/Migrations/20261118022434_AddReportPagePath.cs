using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportingDashboard.Migrations
{
    /// <inheritdoc />
    public partial class AddReportPagePath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PagePath",
                table: "Reports",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: 1,
                column: "PagePath",
                value: "reports/regional-sales");

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: 2,
                column: "PagePath",
                value: "reports/department-expenses");

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: 3,
                column: "PagePath",
                value: "reports/profit-overview");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PagePath",
                table: "Reports");
        }
    }
}
