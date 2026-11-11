using Microsoft.EntityFrameworkCore;
using ReportingDashboard.Data;

namespace ReportingDashboard.Services;

// Tracks which sample user the dashboard is being viewed as.
public class ActiveUserService(
    IDbContextFactory<ApplicationDbContext> dbFactory,
    IHttpContextAccessor httpContextAccessor)
{
    public const string CookieName = "ViewAsUserId";

    // Default to the least-privileged sample user.
    private const int DefaultUserId = 1;

    public async Task<List<User>> GetAllUsersAsync()
    {
        using var db = dbFactory.CreateDbContext();
        return await db.ReportUsers
            .Include(u => u.Role)
            .OrderBy(u => u.RoleId)
            .ThenBy(u => u.Name)
            .ToListAsync();
    }

    public async Task<User?> GetActiveUserAsync()
    {
        var cookie = httpContextAccessor.HttpContext?
            .Request.Cookies[CookieName];

        if (!int.TryParse(cookie, out var userId))
        {
            userId = DefaultUserId;
        }

        return await LoadUserAsync(userId)
            ?? await LoadUserAsync(DefaultUserId);
    }

    public async Task<List<Report>> GetPermittedReportsAsync()
    {
        var user = await GetActiveUserAsync();
        if (user?.Role is null)
        {
            return [];
        }

        var reportIds = user.Role.Permissions
            .Select(p => p.ReportId)
            .ToList();

        using var db = dbFactory.CreateDbContext();
        return await db.Reports
            .Where(r => reportIds.Contains(r.ReportId))
            .OrderBy(r => r.ReportId)
            .ToListAsync();
    }

    public async Task<bool> CanViewAsync(Report report)
    {
        var user = await GetActiveUserAsync();
        return user?.Role?.HasAccessTo(report) ?? false;
    }

    private async Task<User?> LoadUserAsync(int userId)
    {
        using var db = dbFactory.CreateDbContext();
        return await db.ReportUsers
            .Include(u => u.Role!)
            .ThenInclude(r => r.Permissions)
            .FirstOrDefaultAsync(u => u.UserId == userId);
    }
}