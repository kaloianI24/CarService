using CarService.Data;
using CarService.Data.Entities;
using CarService.Repository;
using CarService.Repository.Interface;
using CarService.Service;
using CarService.Service.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Use the correct connection string name consistently
string connectionString = builder.Configuration.GetConnectionString("Auto_Shop") ??
                throw new InvalidOperationException("Connection string Auto_Shop is not found");

// Add services to the container.
builder.Services.AddControllersWithViews();

// Use the correct method for MySQL, UseMySql (not UseMySQL)
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 23))));

builder.Services.AddScoped<IAutoPartsRepository, AutoPartsRepository>();
builder.Services.AddScoped<IAutoPartsService, AutoPartsService>();
builder.Services.AddRazorPages();

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
    pattern: "{controller=AutoParts}/{action=Index}/{id?}");

app.Run();
