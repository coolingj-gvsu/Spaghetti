namespace ReportingDashboard.Data;

public class Role
{
    public int RoleId { get; set; }
    public string RoleName { get; set; } = "";

    public List<User> Users { get; set; } = [];
    public List<ReportPermission> Permissions { get; set; } = [];

    public bool HasAccessTo(Report report) =>
        Permissions.Any(p => p.ReportId == report.ReportId);
}