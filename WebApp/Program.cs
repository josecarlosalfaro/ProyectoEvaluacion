using DtaAccess.BsnLogic.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies", options =>
    {
        options.LoginPath = "/Cuenta/Login";
        options.AccessDeniedPath = "/Cuenta/AccesoDenegado";
    });

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options =>
//    {
//        options.LoginPath = "/Cuenta/Login";
//        options.AccessDeniedPath = "/Cuenta/AccesoDenegado";
//    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("GrupoAdmin", policy => policy.RequireClaim("Grupo", "Admin"));
    options.AddPolicy("GrupoProduccion", policy => policy.RequireClaim("Grupo", "Producción"));
    options.AddPolicy("GrupoVentas", policy => policy.RequireClaim("Grupo", "Ventas"));
});


builder.Services.AddControllersWithViews();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=Home}/{action=Index}/{id?}");
    pattern: "{controller=Cuenta}/{action=Login}/{id?}");
app.Run();

