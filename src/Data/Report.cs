namespace ReportingDashboard.Data;

public class Report
{
    public int ReportId { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string Category { get; set; } = "";
    public string PagePath { get; set; } = "";

    public List<ReportPermission> Permissions { get; set; } = [];
}