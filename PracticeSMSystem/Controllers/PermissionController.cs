using Microsoft.AspNetCore.Mvc;  //with Check boxes
using Microsoft.EntityFrameworkCore;
using PracticeSMSystem.Data.Enums;
using PracticeNewSms.Filters;
using PracticeSMSystem.Data.Database;
using PracticeSMSystem.Data.Models;

namespace PracticeNewSms.Controllers;

public class PermissionController : Controller
{
    private readonly SMSDbContext _context;

    public PermissionController(SMSDbContext context)
    {
        _context = context;
    }

    [FeaturePermission("Permission", AccessLevel.Manage)]
    public IActionResult Manage(int? roleId)
    {
        var roles = _context.Role.ToList();
        ViewBag.Roles = roles;

        if (roleId == null)
        {
            roleId = roles.FirstOrDefault()?.Id;
        }

        var role = _context.Role.Include(r => r.Permissions).ThenInclude(p => p.Feature).FirstOrDefault(r => r.Id == roleId);

        if (role == null)
        {
            return NotFound();
        }
        var allFeatures = _context.Features.ToList();

        foreach (var feature in allFeatures)
        {
            if (!role.Permissions.Any(p => p.FeatureId == feature.Id))
            {
                role.Permissions.Add(new Permissions
                {
                    FeatureId = feature.Id,
                    RoleId = role.Id,
                    AccessLevel = AccessLevel.None
                });
            }
        }

        _context.SaveChanges();
        return View(role);
    }


    [FeaturePermission("Permission", AccessLevel.UpdatePermissions)]
    [HttpPost]
    public IActionResult UpdatePermissions(Role role)
    {
        var dbRole = _context.Role
            .Include(r => r.Permissions)
            .FirstOrDefault(r => r.Id == role.Id);

        if (dbRole == null)
            return NotFound();

        foreach (var perm in dbRole.Permissions)
        {
            var updated = role.Permissions.FirstOrDefault(p => p.Id == perm.Id);

            if (updated != null)
            {
                int combinedLevel = 0;

                if (updated.SelectedLevels != null)
                {
                    foreach (var level in updated.SelectedLevels)
                    {
                        combinedLevel |= level;   // bitwise OR
                    }
                }

                perm.AccessLevel = (AccessLevel)combinedLevel;
            }
        }

        _context.SaveChanges();

        TempData["Message"] = "Permissions updated successfully!";
        return RedirectToAction("Manage", new { roleId = role.Id });
    }
}






























//---------------------------------------------------------------------
//With Radio Buttons

//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using PracticeSMSystem.Data.Enums;
//using PracticeNewSms.Filters;
//using PracticeSMSystem.Data.Database;
//using PracticeSMSystem.Data.Models;

//namespace PracticeNewSms.Controllers;

//public class PermissionController : Controller
//{
//    private readonly SMSDbContext _context;

//    public PermissionController(SMSDbContext context)
//    {
//        _context = context;
//    }

//    [FeaturePermission("Permission", AccessLevel.Manage)]
//    public IActionResult Manage(int? roleId)
//    {
//        var roles = _context.Role.ToList();
//        ViewBag.Roles = roles;

//        if (roleId == null)
//        {
//            roleId = roles.FirstOrDefault()?.Id;
//        }
//        var role = _context.Role.Include(r => r.Permissions).ThenInclude(p => p.Feature).FirstOrDefault(r => r.Id == roleId);

//        if (role == null)
//        {
//            return NotFound();
//        }

//        var allFeatures = _context.Features.ToList();

//        foreach (var feature in allFeatures)
//        {
//            if (!role.Permissions.Any(p => p.FeatureId == feature.Id))
//            {
//                role.Permissions.Add(new Permissions
//                {
//                    FeatureId = feature.Id,
//                    RoleId = role.Id,
//                    AccessLevel = 0
//                });
//            }
//        }
//        _context.SaveChanges();
//        return View(role);
//    }

//    [FeaturePermission("Permission", AccessLevel.UpdatePermissions)]
//    [HttpPost]
//    public IActionResult UpdatePermissions(Role role)
//    {
//        var dbRole = _context.Role.Include(r => r.Permissions).FirstOrDefault(r => r.Id == role.Id);

//        if (dbRole == null)
//        {
//            return NotFound();
//        }
//        foreach (var permission in dbRole.Permissions)
//        {
//            var updatedPermission = role?.Permissions?.FirstOrDefault(p => p.Id == permission.Id);

//            if (updatedPermission != null)
//            {
//                permission.AccessLevel = updatedPermission.AccessLevel;
//            }
//        }
//        _context.SaveChanges();
//        TempData["Message"] = "Permissions updated successfully!";
//        return RedirectToAction("Manage", new { roleId = role?.Id });
//    }
//}