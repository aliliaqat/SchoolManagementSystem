using Microsoft.AspNetCore.Authentication;   // use in check boxes
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeSMSystem.Data.Database;
using System.Security.Claims;

namespace PracticeNewSms.Controllers;


public class AccountController : BaseController
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

    [HttpPost]
    public IActionResult Authenticate(string UserName, string Password)
    {
        var loginUser = _context.UserAccountABC
            .SingleOrDefault(u => u.UAccountUsername == UserName && u.PasswordHash == Password);

        if (loginUser == null)
        {
            ViewBag.Error = "Invalid credentials";
            return View("Login");
        }

        var role = _context.Role.FirstOrDefault(r => r.Id == loginUser.RoleId);
        var roleName = role?.RoleName ?? "Unknown";

        var permissions = _context.Permissions
            .Include(p => p.Feature)
            .Where(p => p.RoleId == loginUser.RoleId)
            .Select(p => new { p.Feature.Name, p.AccessLevel })
            .ToList();

        var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, loginUser.UAccountUsername),
        new Claim(ClaimTypes.Role, roleName),
        new Claim("RoleId", loginUser.RoleId.ToString())
    };

        // 🔹 Group by feature and combine all AccessLevel flags
        var groupedByFeature = permissions.GroupBy(p => p.Name);

        foreach (var featureGroup in groupedByFeature)
        {
            int combinedLevel = 0;
            foreach (var perm in featureGroup)
            {
                combinedLevel |= (int)perm.AccessLevel; // bitwise OR all flags for this feature
            }

            // store as "FeatureName:NumericBitmask"
            claims.Add(new Claim("Permission", $"{featureGroup.Key}:{combinedLevel}"));
        }

        var identity = new ClaimsIdentity(claims, "MyCookieAuth");
        var principal = new ClaimsPrincipal(identity);

        HttpContext.SignInAsync("MyCookieAuth", principal).GetAwaiter().GetResult();
        HttpContext.Session.SetInt32("RoleId", loginUser.RoleId);
       
        return RedirectToAction("Index", "Home");
    }


    public IActionResult AccessDenied()
    {
        return View();
    }
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login", "Account");
    }
}

















































//-------------------------------------------------------------------------
//using Microsoft.AspNetCore.Authentication;   // use in radio button
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using PracticeSMSystem.Data.Database;
//using System.Security.Claims;

//namespace PracticeNewSms.Controllers;


//public class AccountController : Controller
//{
//    private readonly SMSDbContext _context;

//    public AccountController(SMSDbContext context)
//    {
//        _context = context;
//    }

//    public IActionResult Login()
//    {

//        return View();
//    }

//    [HttpPost]
//    public IActionResult Authenticate(string UserName, string Password)
//    {
//        var loginUser = _context.UserAccountABC.SingleOrDefault(u => u.UAccountUsername == UserName && u.PasswordHash == Password);
//        if (loginUser == null)
//        {
//            ViewBag.Error = "Invalid credentials";
//            return View("Login");
//        }

//        var role = _context.Role.FirstOrDefault(r => r.Id == loginUser.RoleId);
//        var roleName = role?.RoleName ?? "Unknown";

//        var permissions = _context.Permissions
//            .Include(p => p.Feature)
//            .Where(p => p.RoleId == loginUser.RoleId)
//            .Select(p => new { p.Feature.Name, p.AccessLevel })
//            .ToList();

//        var claims = new List<Claim>
//    {
//        new Claim(ClaimTypes.Name, loginUser.UAccountUsername),
//        new Claim(ClaimTypes.Role, roleName),
//        new Claim("RoleId", loginUser.RoleId.ToString())
//    };

//        foreach (var p in permissions)
//        {
//            // store as "FeatureName:AccessInt"
//            claims.Add(new Claim("Permission", $"{p.Name}:{p.AccessLevel}"));
//        }

//        var identity = new ClaimsIdentity(claims, "MyCookieAuth");
//        var principal = new ClaimsPrincipal(identity);

//        HttpContext.SignInAsync("MyCookieAuth", principal).GetAwaiter().GetResult();
//        HttpContext.Session.SetInt32("RoleId", loginUser.RoleId);

//        return RedirectToAction("Index", "Home");
//    }
//    public IActionResult AccessDenied()
//    {
//        return View();
//    }
//    public IActionResult Logout()
//    {
//        HttpContext.Session.Clear();
//        return RedirectToAction("Login", "Account");
//    }
//}


