using HolaGuide.Hubs;
using Infrastructure.SQLServer;
using Microsoft.EntityFrameworkCore;
using Services.DBRepository.Implements;
using Services.DBRepository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR();
builder.Services.AddMvc().AddRazorPagesOptions(option => option.Conventions.AddPageRoute("/Home/UserHome",""));

builder.Services.AddDbContext<HolaGuide_TestContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IServiceRepository, ServiceRepository>();
builder.Services.AddTransient<ISavedServiceRepository, SavedServiceRepository>();
builder.Services.AddTransient<ISubscriptionRepository, SubscriptionRepository>();
builder.Services.AddTransient<IUserSubscriptionRepository, UserSubscriptionRepository>();
builder.Services.AddTransient<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddTransient<IImageRepository, ImageRepository>();

builder.Services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth", option =>
{
    option.Cookie.Name = "MyCookieAuth";
    option.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    option.LoginPath = "/Authentication/Login";
    option.AccessDeniedPath = "/Static/AccessDenied";
});

builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("Admin", policy =>
    {
        policy.RequireClaim("Role", "admin");
    });
    option.AddPolicy("User", policy =>
    {
        policy.RequireClaim("Role", "user");
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
    app.UseExceptionHandler("/Static/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();


app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapHub<ServiceHub>("/serviceHub");
});

app.Run();

