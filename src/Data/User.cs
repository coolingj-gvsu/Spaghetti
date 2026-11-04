namespace ReportingDashboard.Data;

public class User
{
    public int UserId { get; set; }
    public string Name { get; set; } = "";
    public int RoleId { get; set; }
    public Role? Role { get; set; }

    public string GetDisplayName() => Role is null ? Name : $"{Name} ({Role.RoleName})";
}