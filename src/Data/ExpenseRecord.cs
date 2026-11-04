namespace ReportingDashboard.Data;

public class ExpenseRecord
{
    public int ExpenseRecordId { get; set; }
    public DateOnly Month { get; set; }
    public string Department { get; set; } = "";
    public decimal Amount { get; set; }
}