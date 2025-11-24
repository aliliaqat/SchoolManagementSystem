using Microsoft.AspNetCore.Http; // 👈 CookieSecurePolicy ke liye
using Microsoft.AspNetCore.Mvc; // 👈 Controller type ke liye
using Microsoft.EntityFrameworkCore;
using PracticeNewSms.Filters;
using PracticeSMSystem.Data.Database;
using System.Reflection;       // 👈 Assembly ke liye
using PracticeSMSystem.Data.Models;




var builder = WebApplication.CreateBuilder(args);

// -------------------------
// Database Context Register
// -------------------------
builder.Services.AddDbContext<SMSDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("PracticeNewSms")
    )
);

// -------------------------
// Session
// -------------------------

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.Name = ".MyApp.Session";
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;

    if (builder.Environment.IsDevelopment())
    {
        // 👇 Local testing me http allowed
        options.Cookie.SecurePolicy = CookieSecurePolicy.None;
    }
    else
    {
        // 👇 Production me sirf https
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    }
});

// -------------------------
// Authentication (Missing Earlier)
// -------------------------
builder.Services.AddAuthentication("MyCookieAuth")
    .AddCookie("MyCookieAuth", options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });



// -------------------------
// MVC Controllers + Views

// ✅ Add Razor Runtime Compilation
//Browser mein dikhne wala error message.
//-------------------------

builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

var app = builder.Build();

// -------------------------
// Ensure Features Registered
// -------------------------
void EnsureFeaturesRegistered(SMSDbContext db)
{
    var controllers = Assembly.GetExecutingAssembly()
        .GetTypes()
        .Where(t => t.IsSubclassOf(typeof(Controller)))
        .ToList();

    foreach (var t in controllers)
    {
        var name = t.Name.Replace("Controller", "");
        if (!db.Features.Any(f => f.Name == name))
        {
            db.Features.Add(new Feature { Name = name, DisplayName = name });
        }
    }
    db.SaveChanges();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<SMSDbContext>();
    EnsureFeaturesRegistered(db);
}

// -------------------------
// Middleware Pipeline
// -------------------------

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();  // ✅ enable https redirect always
app.UseStaticFiles();

app.UseRouting();

app.UseSession();            // ✅ Session
app.UseAuthentication();     // ✅ Authentication
app.UseAuthorization();      // ✅ Authorization

// -------------------------
// Default Route
// -------------------------
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}"
);

app.Run();




