using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ReportingDashboard.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Role> ReportRoles => Set<Role>();
    public DbSet<User> ReportUsers => Set<User>();
    public DbSet<Report> Reports => Set<Report>();
    public DbSet<ReportPermission> ReportPermissions => Set<ReportPermission>();
    public DbSet<SalesRecord> SalesRecords => Set<SalesRecord>();
    public DbSet<ExpenseRecord> ExpenseRecords => Set<ExpenseRecord>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ReportPermission>().HasKey(p => new { p.RoleId, p.ReportId });

        builder.Entity<Role>().HasData(
            new Role { RoleId = 1, RoleName = "Employee" },
            new Role { RoleId = 2, RoleName = "Manager" },
            new Role { RoleId = 3, RoleName = "Executive" });

        builder.Entity<User>().HasData(
            new User { UserId = 1, Name = "Jordan Lee", RoleId = 1 },
            new User { UserId = 2, Name = "Sam Patel", RoleId = 1 },
            new User { UserId = 3, Name = "Taylor Brooks", RoleId = 2 },
            new User { UserId = 4, Name = "Morgan Reyes", RoleId = 3 });

        builder.Entity<Report>().HasData(
            new Report
            {
                ReportId = 1,
                Title = "Regional Sales",
                Description = "Monthly sales total by region.",
                Category = "Sales",
                PagePath = "reports/regional-sales"
            },
            new Report
            {
                ReportId = 2,
                Title = "Department Expenses",
                Description = "Monthly expenses by department.",
                Category = "Finance",
                PagePath = "reports/department-expenses"
            },
            new Report
            {
                ReportId = 3,
                Title = "Profit Overview",
                Description = "Company-wide sales compared to expenses.",
                Category = "Executive",
                PagePath = "reports/profit-overview"
            });

        // Employees see sales, managers add expenses, executives see everything. 
        builder.Entity<ReportPermission>().HasData(
            new ReportPermission { RoleId = 1, ReportId = 1 },
            new ReportPermission { RoleId = 2, ReportId = 1 },
            new ReportPermission { RoleId = 2, ReportId = 2 },
            new ReportPermission { RoleId = 3, ReportId = 1 },
            new ReportPermission { RoleId = 3, ReportId = 2 },
            new ReportPermission { RoleId = 3, ReportId = 3 });

        string[] regions = ["North", "South", "East", "West"];
        builder.Entity<SalesRecord>().HasData(
            Enumerable.Range(0, 12).SelectMany(m => regions.Select((region, r) => new SalesRecord
            {
                SalesRecordId = m * regions.Length + r + 1,
                Month = new DateOnly(2026, m + 1, 1),
                Region = region,
                Amount = 20000 + r * 5000 + m * 750
            })));

        string[] departments = ["Sales", "Operations", "IT", "HR"];
        builder.Entity<ExpenseRecord>().HasData(
            Enumerable.Range(0, 12).SelectMany(m => departments.Select((department, d) => new ExpenseRecord
            {
                ExpenseRecordId = m * departments.Length + d + 1,
                Month = new DateOnly(2026, m + 1, 1),
                Department = department,
                Amount = 8000 + d * 3000 + (m % 3) * 500
            })));
    }
}