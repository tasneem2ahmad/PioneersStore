using Microsoft.EntityFrameworkCore;
using Pioneers.BLL.Interfaces;
using Pioneers.BLL.Repositories;
using Pioneers.DAL.Context;
using PioneersStore.Mappers;
using StoreDashboard.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StoreContext>(options =>
options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IMarketRepository, MarketRepository>();
builder.Services.AddScoped<IFeatureRepository, FeatureRepository>();
builder.Services.AddScoped<IChildDepartmentRepository, ChildDepartmentRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(m => m.AddProfile(new DepartmentProfile()));
builder.Services.AddAutoMapper(m => m.AddProfile(new MarketProfile()));
builder.Services.AddAutoMapper(m => m.AddProfile(new FeatureProfile()));
builder.Services.AddAutoMapper(m => m.AddProfile(new ChildDepartmentProfile()));

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
