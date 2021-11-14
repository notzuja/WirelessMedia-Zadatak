using Microsoft.EntityFrameworkCore;
using WMPrakticniZadatak.Common.Settings;
using WMPrakticniZadatak.DAL.Contexts;
using WMPrakticniZadatak.DAL.Repositories.JSON;
using WMPrakticniZadatak.DAL.Repositories.JSON.Interfaces;
using WMPrakticniZadatak.Services;
using WMPrakticniZadatak.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registering EF Core dbContexts as DI services
builder.Services.AddDbContext<ProductContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WMPrakticniZadatak")), ServiceLifetime.Scoped);

// Adding access to configuration via Options pattern
builder.Services.Configure<DataAccessOptions>(builder.Configuration.GetSection("DataAccess"));
builder.Services.AddScoped<IProductRepository, ProductJsonRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

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
