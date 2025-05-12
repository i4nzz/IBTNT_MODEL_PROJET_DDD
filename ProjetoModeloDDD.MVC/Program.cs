using Microsoft.EntityFrameworkCore;
using ProjetoModeloDDD.Infra.Data.Context;
//using ProjetoModeloDDD.MVC.IoC; // Importa a IoC
using ProjetoModeloDDD.IoC;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<ProjetoModeloContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// MVC
builder.Services.AddControllersWithViews();

// REGISTRA DEPENDÊNCIAS
builder.Services.RegisterServices();

var app = builder.Build();

// Pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
