using System;
using Microsoft.EntityFrameworkCore;
using RSVPinvites.Data;
using RSVPinvites.Models;
using RSVPinvites.Interfaces;
using System.Text.RegularExpressions;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IWeddingInvites, WeddingInvitesRepo>();
builder.Services.AddControllersWithViews();
// builder.Services.AddDbContext<AppDbContext>(opt => 
//     opt.UseNpgsql(builder.Configuration.GetConnectionString("RSVPApp")));
builder.Services.AddDbContext<AppDbContext>(options =>
{
  if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
  {
    var m = Regex.Match(Environment.GetEnvironmentVariable("DATABASE_URL")!, @"postgres://(.*):(.*)@(.*):(.*)/(.*)");
    options.UseNpgsql($"Server={m.Groups[3]};Port={m.Groups[4]};User Id={m.Groups[1]};Password={m.Groups[2]};Database={m.Groups[5]};sslmode=Prefer;Trust Server Certificate=true");
  } 
  else // In Development Environment
  {
    // So, use a local Connection
    options.UseNpgsql(builder.Configuration.GetConnectionString("RSVPApp"));
  }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
