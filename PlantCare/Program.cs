using PlantCare;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using PlantCare.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PlantCareDBContext>(options =>
    options.UseSqlServer("Server=localhost;Database=PlantCare;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=true"));

builder.Services.AddScoped<IPlantInfoService, PlantInfoService>();

var app = builder.Build();

var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<PlantCareDBContext>();

await dbContext.Database.MigrateAsync();

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
