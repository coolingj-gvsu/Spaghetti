namespace ReportingDashboard.Data;

public class SalesRecord
{
    public int SalesRecordId { get; set; }
    public DateOnly Month { get; set; }
    public string Region { get; set; } = "";
    public decimal Amount { get; set; }
}