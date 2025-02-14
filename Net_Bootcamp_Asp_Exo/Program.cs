using Microsoft.EntityFrameworkCore;
using Net_Bootcamp_Asp_Exo.BLL.Interfaces;
using Net_Bootcamp_Asp_Exo.BLL.Services;
using Net_Bootcamp_Asp_Exo.DAL.Data;
using Net_Bootcamp_Asp_Exo.DAL.Interfaces;
using Net_Bootcamp_Asp_Exo.DAL.Repositories;
using Net_Bootcamp_Asp_Exo.Domain.Entities;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUtilisateurService, UtilisateurService>();

bool useEntity = builder.Configuration.GetValue<bool>("useEntity");

if (useEntity)
{
    builder.Services.AddScoped<IUtilisateurRepository, UtilisateurRepository>();

}
else
{
    builder.Services.AddScoped<IUtilisateurRepository, UtilisateurRepositoryAdo>();
}

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
