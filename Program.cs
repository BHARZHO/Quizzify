// using Microsoft.EntityFrameworkCore;
// using Quiziffy_App.Data;

// var builder = WebApplication.CreateBuilder(args);

// // Get connection string
// var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// if (connectionString is null)
// {
//     throw new ArgumentNullException("PLese Provide a valid configuration");
// }

// // Register MySQL database context
// builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySQL(connectionString));

// builder.Services.AddControllersWithViews();

// var app = builder.Build();
// await app.Services.InitializeDbAsync();

// app.UseHttpsRedirection();
// app.UseStaticFiles();
// app.UseRouting();
// app.UseAuthorization();

// app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

// app.Run();


using Quiziffy.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure MySQL with Entity Framework
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySQL("DefaultConnection"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();