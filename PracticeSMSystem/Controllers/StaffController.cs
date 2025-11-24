using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticeNewSms.Common;
using PracticeNewSms.Controllers;
using PracticeNewSms.Filters;
using PracticeSMSystem.Data.Database;
using PracticeSMSystem.Data.Enums;
using PracticeSMSystem.Data.Models;
using System;
using System.Linq;

namespace PracticeSMSystem.Controllers;

public class StaffController : BaseController
{
    private readonly SMSDbContext _context;

    public StaffController(SMSDbContext context)
    {
        
        _context = context;
    }


    [FeaturePermission("Staff", AccessLevel.View)]
    public IActionResult Index()
    {
        List<string> permClaims = (List<string>)HttpContext?.Items["permClaims"];

        var staffList = _context.Staff.Where(s => !s.IsDeleted).ToList();
        ViewBag.RoleList = _context.Role.ToDictionary(a => a.Id, b => b.RoleName);
        ViewBag.Edit = PermissionEvaluator.IsAllowed(permClaims, "Staff", AccessLevel.Edit);
        ViewBag.Delete = PermissionEvaluator.IsAllowed(permClaims, "Staff", AccessLevel.Delete);
        return View("StaffList", staffList);
    }


    [FeaturePermission("Staff", AccessLevel.Details)]
    [HttpGet]
    public IActionResult Details(int id)
    {
        var staff = _context.Staff.FirstOrDefault(s => s.Id == id && !s.IsDeleted);
        if (staff == null)
        {
            return NotFound();
        }

        return View(staff);
    }


    [FeaturePermission("Staff", AccessLevel.Create)]
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Rolelist = _context.Role.ToList();
        return View();
    }


    [FeaturePermission("Staff", AccessLevel.Create)]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Staff staff)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Rolelist = _context.Role.ToList();
            return View(staff);
        }
           
        SetAuditFields(staff, isNew: true);
        _context.Staff.Add(staff);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }


    [FeaturePermission("Staff", AccessLevel.Edit)]
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var staff = _context.Staff.FirstOrDefault(s => s.Id == id && !s.IsDeleted);
        ViewBag.Rolelist = _context.Role.ToList();

        if (staff == null)
        {
            staff = new Staff();
        }
        return View(staff);
    }


    [FeaturePermission("Staff", AccessLevel.Edit)]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Staff staff)
    {
        if (!ModelState.IsValid)
        {
            return View(staff);
        }
           
        var existingStaff = _context.Staff.FirstOrDefault(s => s.Id == staff.Id) ?? new Staff();
        CopyStaffFields(staff, existingStaff);
        SetAuditFields(existingStaff, isNew: staff.Id == 0);

        if (staff.Id == 0)
            _context.Staff.Add(existingStaff);

        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }


    [FeaturePermission("Staff", AccessLevel.Delete)]
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var staff = _context.Staff.FirstOrDefault(s => s.Id == id && !s.IsDeleted);
        if (staff == null)
        {
            return NotFound();
        }

        return View(staff);
    }


    [FeaturePermission("Staff", AccessLevel.Delete)]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var staff = _context.Staff.FirstOrDefault(s => s.Id == id);
        if (staff == null)
        {
            return NotFound();
        }

        staff.IsDeleted = true;
        staff.DeletedOn = DateTime.Now;
        staff.DeletedBy = 1;

        _context.Staff.Update(staff);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }


    [FeaturePermission("Staff", AccessLevel.SetAuditFields)]
    // 🔄 Helper Methods
    private void SetAuditFields(Staff staff, bool isNew)
    {
        if (isNew)
        {
            staff.CreatedOn = DateTime.Now;
            staff.CreatedBy = 1;
            staff.IsDeleted = false;
        }
        staff.UpdatedOn = DateTime.Now;
        staff.UpdatedBy = 1;
    }

    [FeaturePermission("Staff", AccessLevel.CopyStaffFields)]
    // 🔄 Helper Methods
    private void CopyStaffFields(Staff source, Staff target)
    {
        target.FirstName = source.FirstName;
        target.LastName = source.LastName;
        target.Gender = source.Gender;
        target.Dob = source.Dob;
        target.HireDate = source.HireDate;
        target.Position = source.Position;
        target.RoleId = source.RoleId;
        target.Email = source.Email;
        target.Phone = source.Phone;
    }
}