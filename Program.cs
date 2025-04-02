using Microsoft.EntityFrameworkCore;
using Quiziffy_App.Data;

var builder = WebApplication.CreateBuilder(args);

// Get connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (connectionString is null)
{
    throw new ArgumentNullException("PLese Provide a valid configuration");
}

// Register MySQL database context
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySQL(connectionString));

builder.Services.AddControllersWithViews();

var app = builder.Build();
await app.Services.InitializeDbAsync();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
