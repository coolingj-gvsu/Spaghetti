namespace ReportingDashboard.Data;

public class ReportPermission
{
    public int RoleId { get; set; }
    public Role? Role { get; set; }
    public int ReportId { get; set; }
    public Report? Report { get; set; }
}