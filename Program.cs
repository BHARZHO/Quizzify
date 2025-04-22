// using Microsoft.EntityFrameworkCore;
// using Quiziffy_App.Data;

// var builder = WebApplication.CreateBuilder(args);


// builder.Services.AddControllersWithViews();

// var app = builder.Build();

// app.UseHttpsRedirection();
// app.UseStaticFiles();
// app.UseRouting();
// app.UseAuthorization();

// app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

// app.Run();


using Quiziffy.Data;
using Microsoft.EntityFrameworkCore;
using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddNotyf(config=> { config.DurationInSeconds = 10;config.IsDismissable = true;config.Position = NotyfPosition.BottomRight; });

// Configure MySQL with Entity Framework
// // Get connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (connectionString is null)
{
    throw new ArgumentNullException("PLese Provide a valid configuration");
}

// Register MySQL database context
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySQL(connectionString));

var app = builder.Build();
await app.Services.InitializeDbAsync(); // i added this for migrtions


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseNotyf();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();