using DAL;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using BLL.Interfaces;
using BLL.Classes;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IReadImagesAdress, ReadImagesAdress>();
builder.Services.AddScoped<IShowOrderList, ShowOrderList>();
builder.Services.AddScoped<SendEmail>();


//builder.Services.AddScoped<IReadImagesAdress, ReadImagesAdress>();
//builder.Services.AddScoped<>
//builder.Services.AddDbContext<OrderDbcontext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("YourConnectionString")));

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
    pattern: "{controller=Home}/{action=HomePage}/{id?}");


app.Run();
