using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RCALogBuilder.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

// Register IMarkdownExporter
builder.Services.AddScoped<IMarkdownExporter, MarkdownExporter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Map Razor Pages. Use a fallback to the Incident page so the site root (/) serves the Incident page.
app.MapRazorPages();

// If you still use MVC controllers, keep the default route for them
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Fallback the root to the Incident Razor Page (so / serves the Incident form)
// The page for Pages/Incident/Index.cshtml is "/Incident/Index" so use that exact route.
app.MapFallbackToPage("/Incident/Index");

app.Run();
