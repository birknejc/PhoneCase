using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using PhoneCase;
using PhoneCase.DBServices;
using PhoneCase.Data;
using PhoneCase.Models;
using PhoneCase.Pages;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Connect directly to the SQL Server database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=cases;Trusted_Connection=True;TrustServerCertificate=True;"));

// Add SignalR services
builder.Services.AddSignalR();

// Configure CORS policy
builder.Services.AddCors(options =>
{
options.AddPolicy("AllowSpecificOrigin",
    builder => builder.WithOrigins("https://example.com") // Replace with your front-end URL
                      .AllowAnyHeader()
                      .AllowAnyMethod()
                      .AllowCredentials());
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

// Use CORS policy
app.UseCors("AllowSpecificOrigin");

app.MapBlazorHub();
app.MapHub<LiveUpdateHub>("/liveupdatehub");
app.MapFallbackToPage("/_Host");

app.Run();
