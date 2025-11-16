using Microsoft.EntityFrameworkCore;
using PracticeSMSystem.Data.Database;
using Microsoft.AspNetCore.Http; // 👈 CookieSecurePolicy ke liye

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
// MVC Controllers + Views

// ✅ Add Razor Runtime Compilation
//-------------------------


builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

var app = builder.Build();

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
