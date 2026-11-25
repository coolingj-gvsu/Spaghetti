namespace ReportingDashboard.Reports;

// A report's data laid out as a simple table, used for PDF export.
public record ReportTable(
    List<string> Columns,
    List<List<string>> Rows,
    List<string> Footer)
{
    // Builds a Month x Group table with a Total column and a Total row.
    public static ReportTable Pivot<T>(
        List<T> records,
        Func<T, DateOnly> month,
        Func<T, string> group,
        Func<T, decimal> amount)
    {
        var groups = records.Select(group).Distinct().ToList();
        var months = records.Select(month).Distinct().Order().ToList();

        string Total(Func<T, bool> filter) =>
            records.Where(filter).Sum(amount).ToString("C0");

        var rows = months
            .Select(m => new List<string> { m.ToString("MMM yyyy") }
                .Concat(groups.Select(g => Total(r => month(r) == m && group(r) == g)))
                .Append(Total(r => month(r) == m))
                .ToList())
            .ToList();

        var footer = new List<string> { "Total" }
            .Concat(groups.Select(g => Total(r => group(r) == g)))
            .Append(Total(_ => true))
            .ToList();

        return new ReportTable(["Month", .. groups, "Total"], rows, footer);
    }
}
