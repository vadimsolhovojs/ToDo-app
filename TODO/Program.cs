using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TODO.Core.Models;
using TODO.Core.Services;
using TODO.Data;
using TODO.Services;
using TODO.UseCases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContextPool<ToDoDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("todo-app"));
});
builder.Services.AddTransient<IToDoDbContext, ToDoDbContext>();
builder.Services.AddTransient<IEntityService<Item>, EntityService<Item>>();
builder.Services.AddTransient<IItemService, ItemService>();
builder.Services.AddServices();


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