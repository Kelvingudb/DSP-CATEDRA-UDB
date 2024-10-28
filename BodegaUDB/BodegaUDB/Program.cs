using BodegaUDB.Models;
using BodegaUDB.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Autenticacion de la sesion
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Ruta para redirigir si no está autenticado
        options.LogoutPath = "/Account/Logout"; // Ruta para cerrar sesión
    });

//Servicios para el sistema.
builder.Services.AddScoped<IAuthService, AuthService>();


//Service de la BDD.
builder.Services.AddDbContext<BodegaDspContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("BodegaDspContext"));
    });


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Index}/{id?}");

app.Run();
