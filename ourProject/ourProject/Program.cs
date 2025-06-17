using DAL;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using BLL.Interfaces;
using BLL.Classes;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IReadImagesAdress, ReadImagesAdress>();
builder.Services.AddScoped<IShowOrderList, ShowOrderList>();
builder.Services.AddScoped<SendEmail>();


var app = builder.Build();

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
    pattern: "{controller=Home}/{action=HomePage}/{id?}");


app.Run();
