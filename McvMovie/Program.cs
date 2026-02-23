using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using McvMovie.Data;
using McvMovie.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<McvMovieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("McvMovieContext")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Seed database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();