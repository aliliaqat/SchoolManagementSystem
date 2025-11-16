using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeSMSystem.Data.Database;
using PracticeSMSystem.Data.Models;

namespace PracticeNewSms.Controllers
{
    public class PermissionController : Controller
    {
        private readonly SMSDbContext _context;

        public PermissionController(SMSDbContext context)
        {
            _context = context;
        }
        
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
                    role.Permissions.Add(new Permission
                    {
                        FeatureId = feature.Id,
                        RoleId = role.Id,
                        AccessLevel = 0
                    });
                }
            }
            _context.SaveChanges();
            return View(role);
        }


        [HttpPost]
        public IActionResult UpdatePermissions(Role role)
        {
            var dbRole = _context.Role.Include(r => r.Permissions).FirstOrDefault(r => r.Id == role.Id);

            if (dbRole == null)
            {
                return NotFound();
            }
            foreach (var permission in dbRole.Permissions)
            {
                var updatedPermission = role?.Permissions?.FirstOrDefault(p => p.Id == permission.Id);

                if (updatedPermission != null)
                {
                    permission.AccessLevel = updatedPermission.AccessLevel;
                }
            }
            _context.SaveChanges();
            TempData["Message"] = "Permissions updated successfully!";
            return RedirectToAction("Manage"/*, new { roleId = role?.Id }*/);
        }
    }
}