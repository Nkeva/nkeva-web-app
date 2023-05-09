using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using nkeva_web_app;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var db = "Server=(localdb)\\mssqllocaldb;Database=SchoolPlatform;Trusted_Connection=True;MultipleActiveResultSets=true";

builder.Services.AddDbContext<DbApp>(options =>
    options.UseSqlServer(db));
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
        options.LogoutPath = "/logout";
        options.AccessDeniedPath = "/AccessDenied";
    });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { 
        Title = "NKEVA - School Platform",
        Version = "v1",
        TermsOfService = new Uri("https://github.com/Nkeva"),
    });
});
builder.Services.AddSwaggerGen();

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

app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.UseSwagger();
app.UseSwaggerUI();

app.MapFallbackToFile("index.html"); ;

app.Run();
