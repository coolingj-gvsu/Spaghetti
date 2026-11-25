using Microsoft.EntityFrameworkCore;
using ReportingDashboard.Data;

namespace ReportingDashboard.Reports;

// Each report that can be exported to PDF implements this.
public interface IReportExport
{
    int ReportId { get; }
    Task<ReportTable> BuildTableAsync(ApplicationDbContext db);
}

public class RegionalSalesExport : IReportExport
{
    public int ReportId => 1;

    public async Task<ReportTable> BuildTableAsync(ApplicationDbContext db) =>
        ReportTable.Pivot(await db.SalesRecords.ToListAsync(),
            s => s.Month, s => s.Region, s => s.Amount);
}

public class DepartmentExpensesExport : IReportExport
{
    public int ReportId => 2;

    public async Task<ReportTable> BuildTableAsync(ApplicationDbContext db) =>
        ReportTable.Pivot(await db.ExpenseRecords.ToListAsync(),
            e => e.Month, e => e.Department, e => e.Amount);
}

public class ProfitOverviewExport : IReportExport
{
    public int ReportId => 3;

    public async Task<ReportTable> BuildTableAsync(ApplicationDbContext db)
    {
        var sales = await db.SalesRecords.ToListAsync();
        var expenses = await db.ExpenseRecords.ToListAsync();
        var months = sales.Select(s => s.Month)
            .Union(expenses.Select(e => e.Month))
            .Order()
            .ToList();

        List<string> Row(string label, decimal salesTotal, decimal expenseTotal) =>
            [label, salesTotal.ToString("C0"), expenseTotal.ToString("C0"),
             (salesTotal - expenseTotal).ToString("C0")];

        var rows = months.Select(m => Row(
            m.ToString("MMM yyyy"),
            sales.Where(s => s.Month == m).Sum(s => s.Amount),
            expenses.Where(e => e.Month == m).Sum(e => e.Amount)))
            .ToList();

        return new ReportTable(
            ["Month", "Sales", "Expenses", "Profit"],
            rows,
            Row("Total", sales.Sum(s => s.Amount), expenses.Sum(e => e.Amount)));
    }
}
