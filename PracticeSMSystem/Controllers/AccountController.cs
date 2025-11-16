using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PracticeSMSystem.Data.Database;
using System.Security.Claims;

namespace PracticeNewSms.Controllers;

public class AccountController : Controller
{
    private readonly SMSDbContext _context;

    public AccountController(SMSDbContext context)
    {
        _context = context;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]   // Authenticate POST
    public IActionResult Authenticate(string UserName, string Password)
    {
        var loginUser = _context.UserAccountABC.SingleOrDefault(u => u.UAccountUsername == UserName && u.PasswordHash == Password);

        if (loginUser == null)
        {
            ViewBag.Error = "Invalid credentials";
            return View("Login");
        }
        var roleName = _context.Role.Where(r => r.Id == loginUser.RoleId).Select(r => r.RoleName).FirstOrDefault();

        var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, loginUser.UAccountUsername),
        new Claim(ClaimTypes.Role, roleName)
    };

        var identity = new ClaimsIdentity(claims, "MyCookieAuth");
        var principal = new ClaimsPrincipal(identity);

        HttpContext.SignInAsync("MyCookieAuth", principal).GetAwaiter().GetResult();

        return RedirectToAction("Index", "Home");
    }
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login", "Account");
    }
    public IActionResult GetDataFromDb()
    { return View(); }
}


