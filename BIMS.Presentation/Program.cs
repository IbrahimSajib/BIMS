using BIMS.DataAccess.Data;
using BIMS.DataAccess.IRepository.Auth;
using BIMS.DataAccess.Repository.Auth;
using BIMS.Services.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<BIMSDbContext>();

builder.Services.AddDbContext<BIMSDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyCS")));





builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();







var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
