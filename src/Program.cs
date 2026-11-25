using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReportingDashboard.Components;
using ReportingDashboard.Components.Account;
using ReportingDashboard.Data;
using Microsoft.AspNetCore.Mvc;
using ReportingDashboard.Services;
using QuestPDF.Infrastructure;
using ReportingDashboard.Reports;

var builder = WebApplication.CreateBuilder(args);

QuestPDF.Settings.License = LicenseType.Community;

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ActiveUserService>();
builder.Services.AddSingleton<IReportExport, RegionalSalesExport>();
builder.Services.AddSingleton<IReportExport, DepartmentExpensesExport>();
builder.Services.AddSingleton<IReportExport, ProfitOverviewExport>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

// Saves the "View As" selection in a cookie, then returns to the page.
app.MapPost("/view-as", (
    [FromForm] int userId,
    [FromForm] string? returnUrl,
    HttpContext context) =>
{
    context.Response.Cookies.Append(
        ActiveUserService.CookieName,
        userId.ToString(),
        new CookieOptions { HttpOnly = true, IsEssential = true });

    var isLocal = returnUrl is not null
        && returnUrl.StartsWith('/')
        && !returnUrl.StartsWith("//")
        && !returnUrl.StartsWith("/\\");

    return Results.LocalRedirect(isLocal ? returnUrl! : "/");
});

// Exports a report to PDF after checking the active user's permission.
app.MapGet("/reports/{reportId:int}/pdf", async (
    int reportId,
    IDbContextFactory<ApplicationDbContext> dbFactory,
    ActiveUserService activeUsers,
    IEnumerable<IReportExport> exports,
    ILogger<Program> logger) =>
{
    using var db = await dbFactory.CreateDbContextAsync();

    var report = await db.Reports.FindAsync(reportId);
    var export = exports.FirstOrDefault(e => e.ReportId == reportId);
    if (report is null || export is null)
    {
        return Results.NotFound();
    }

    if (!await activeUsers.CanViewAsync(report))
    {
        return Results.StatusCode(StatusCodes.Status403Forbidden);
    }

    try
    {
        var user = await activeUsers.GetActiveUserAsync();
        var table = await export.BuildTableAsync(db);
        var pdf = ReportPdf.Generate(report, table, user?.GetDisplayName() ?? "Unknown");
        var fileName = $"{report.Title.Replace(' ', '-')}-{DateTime.Now:yyyy-MM-dd}.pdf";
        return Results.File(pdf, "application/pdf", fileName);
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Failed to export report {ReportId} to PDF", reportId);
        return Results.Problem("The report could not be exported to PDF.");
    }
});

app.Run();
