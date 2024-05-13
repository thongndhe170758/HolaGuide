using Infrastructure.SQLServer;
using Microsoft.EntityFrameworkCore;
using Services.DBRepository.Implements;
using Services.DBRepository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<HolaGuide_TestContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth", option =>
{
    option.Cookie.Name = "MyCookieAuth";
    option.ExpireTimeSpan = TimeSpan.FromMinutes(1);
    option.LoginPath = "/Authentication/Unauthenticated";
    option.AccessDeniedPath = "/Authentication/AccessDenied";
});

builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("Admin", policy =>
    {
        policy.RequireClaim("Role", "2");
    });
    option.AddPolicy("User", policy =>
    {
        policy.RequireClaim("Role", "1");
    });
});

builder.Services.AddSession(cfg =>
{
    cfg.IdleTimeout = TimeSpan.FromMinutes(10);
    cfg.Cookie.HttpOnly = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();

