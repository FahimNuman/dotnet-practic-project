using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Social.Repositories.Administration;
using Social.Repositories.Administration.Interfaces;
using Social.Repositories.DB;
using Social.Repositories.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRepositories();

builder.Services.AddDbContext<SocialDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("SocialDatabase")
));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/Accounts/Login";
        option.AccessDeniedPath = "/Error/AccessDenied";
        option.Cookie.IsEssential = true;
        option.SlidingExpiration = true;
        option.ExpireTimeSpan = TimeSpan.FromDays(30);
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

app.UseCookiePolicy( new CookiePolicyOptions()
{
    MinimumSameSitePolicy=SameSiteMode.None
});

app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
      name: "default",
      pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
