using Microsoft.EntityFrameworkCore;
using nkeva_web_app;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var db = "Server=(localdb)\\mssqllocaldb;Database=SchoolPlatform;Trusted_Connection=True;MultipleActiveResultSets=true";

builder.Services.AddDbContext<DbApp>(options =>
    options.UseSqlServer(db));
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
