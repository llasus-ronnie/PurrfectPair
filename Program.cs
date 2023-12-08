using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using PurrfectPair.Data;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.Cookie.IsEssential = true;
});
// Add DbContext configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.AccessDeniedPath = "/Accou nt/AccessDenied";
        options.LoginPath = "/Account/Login"; // Customize this based on your login route
    });

builder.Services.AddMvc();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Use(async (context, next) =>
{
    var user = context.User;

    if (user.Identity.IsAuthenticated)
    {
        // Set user information in the session
        context.Session.SetString("UserID", user.FindFirstValue(ClaimTypes.NameIdentifier));
        context.Session.SetString("FirstName", user.FindFirstValue(ClaimTypes.GivenName));
        context.Session.SetString("LastName", user.FindFirstValue(ClaimTypes.Surname));
        context.Session.SetString("Email", user.FindFirstValue(ClaimTypes.Email));
        context.Session.SetString("ContactNumber", user.FindFirstValue(ClaimTypes.MobilePhone));
        // Add other user properties as needed
    }

    await next();
});

app.Run();
