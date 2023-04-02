using Real_Estate.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Real_Estate.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Real_EstateDbContextConnection") ?? throw new InvalidOperationException("Connection string 'Real_EstateDbContextConnection' not found.");

// Add services to the container.

builder.Services.AddDbContext<RealEstateDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddIdentity<ApplicationUser , IdentityRole>()
    .AddEntityFrameworkStores<RealEstateDbContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Properties}/{action=Properties}/{id?}");


REDbInitializer.Seed(app);
app.Run();


