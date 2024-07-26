using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using SistemaPlania.Client.Servicios.Implementacion;
using SistemaPlania.Server.DataBase;
using SistemaPlania.Server.Email;
using SistemaPlania.Server.Models;
using SistemaPlania.Server.Repositorio.Contrato;
using SistemaPlania.Server.Repositorio.Implementacion;
using SistemaPlania.Server.Utilidades;

using SistemaPlania.Server.ConsultasDB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//builder.Services.AddDbContext<DbventaBlazorContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL"));
//});
//conexcion a base de datos local
builder.Services.AddDbContext<DbventaBlazorContext>(options =>
    options.UseSqlite($"Data Source={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Planias.db")}"));

// Registro del servicio
//var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Planias.db");
//builder.Services.AddScoped<UsuarioDB>(provider => new UsuarioDB(dbPath));



builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IRolRepositorio, RolRepositorio>();
builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
builder.Services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
builder.Services.AddScoped<IVentaRepositorio, VentaRepositorio>();
builder.Services.AddScoped<IDashBoardRepositorio, DashBoardRepositorio>();
// Registro del servicio Email
builder.Services.AddScoped<Email>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
