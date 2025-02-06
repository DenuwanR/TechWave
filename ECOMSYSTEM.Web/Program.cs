using ECOMSYSTEM.Repository.ApplicationUsers;
using ECOMSYSTEM.Repository.ItemDetails;
using ECOMSYSTEM.Repository.OderDetails;
using ECOMSYSTEM.Repository.ProductsDetails;
using ECOMSYSTEM.Shared;
using ECOMSYSTEM.Shared.Models;
using ECOMSYSTEM.Web;
using ECOMSYSTEM.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IMyInterface, MyService>();
builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
builder.Services.AddScoped<IProductDetailsRepository, ProductDetailsrepository>();
builder.Services.AddScoped<IItemCartDetailsRepository, ItemCartDetailsRepository>();
builder.Services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();
builder.Services.AddScoped<IApplicatioUser, ApplicationUserService>();
builder.Services.AddScoped<IOrderDetails, OrderService>();
builder.Services.AddScoped<IProductDetails, ProductService>();
builder.Services.AddScoped<IItemCartDetails, ItemCartService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();
