using BIMS.DataAccess.Data;
using BIMS.DataAccess.IRepository;
using BIMS.DataAccess.IRepository.Auth;
using BIMS.DataAccess.Repository;
using BIMS.DataAccess.Repository.Auth;
using BIMS.Services.IService;
using BIMS.Services.IService.Auth;
using BIMS.Services.Service;
using BIMS.Services.Service.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<BIMSDbContext>();

builder.Services.AddDbContext<BIMSDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyCS")));




//For Register and Login
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();

//For Role Management
builder.Services.AddScoped<IRoleManagementRepository, RoleManagementRepository>();
builder.Services.AddScoped<IRoleManagementService, RoleManagementService>();

//For User Management
builder.Services.AddScoped<IUserManagementRepository, UserManagementRepository>();
builder.Services.AddScoped<IUserManagementService, UserManagementService>();

//For Product-Category
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

//For Supplier
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<ISupplierService, SupplierService>();

//For Customer
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();


//For Product
builder.Services.AddScoped<IProductRepository, ProductRepository>();



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
