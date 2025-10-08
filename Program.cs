using FirstWebApplication.Data;
using FirstWebApplication.Repositories;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// Dapper + repo
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<ObstacleRepository>();

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

// Sett gjerne Obstacle/Overview som startside:
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Obstacle}/{action=DataForm}/{id?}");

app.Run();
