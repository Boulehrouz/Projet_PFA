using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Projet_PFA.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddDbContext<MyContext>(
    opt =>
    {
        opt.UseSqlServer("Data Source=.;Initial Catalog=Projet_PFA; Encrypt=false; Integrated Security=true;");
        opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
