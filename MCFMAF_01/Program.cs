using MCFMAF_01.Database.MasterDB;
using MCFMAF_01.Database.TRDB1;
using MCFMAF_01.Database.TRDB2;
using MCFMAF_01.Services;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

string dbconnection = builder.Configuration.GetConnectionString("DBConnection");
string tr1connection = builder.Configuration.GetConnectionString("TR1Connection");
string tr2connection = builder.Configuration.GetConnectionString("TR2Connection");
//builder.services.AddDbContext<DBContext_B>(ops =>
//{
//    ops.UseSqlServer(Configuration.GetConnectionString($"Connection_B"));
//});


builder.Services.AddDbContext<MasterDbContext>(options =>
{
    options.UseSqlServer(dbconnection);
});

builder.Services.AddDbContext<TransactionDb1Context>(options =>
{
    options.UseSqlServer(tr1connection);
});

builder.Services.AddDbContext<TransactionDb2Context>(options =>
{
    options.UseSqlServer(tr2connection);
});

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<AccountService, AccountServiceImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

}
  
app.UseSession();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
