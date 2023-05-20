using App.Business.Abstract;
using App.Business.Concrete;
using App.DataAccess.Abstract;
using App.DataAccess.Concrete.EFEntityFramework;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Products.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register Database
var conn = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<MyStoreDbContext>(options =>
{
    options.UseSqlServer(conn);
});

// Register Services and Data Access Layers (DALs)
builder.Services.AddScoped<IProductDal, EFProductDal>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipelinez
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

app.UseRewriter(new RewriteOptions().AddRedirect("^$", "home"));
app.Run();