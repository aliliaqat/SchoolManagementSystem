using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticeSMSystem.Data.Enums;
using PracticeNewSms.Filters;
using PracticeSMSystem.Data.Database;
using PracticeSMSystem.Data.Models;
using System;
using System.Linq;


namespace SMSystem.Controllers;
public class RoleController : Controller
{
    private readonly SMSDbContext _context;

    public RoleController(SMSDbContext context)
    {
        _context = context;
    }

    [FeaturePermission("Permission", AccessLevel.View)]
    public IActionResult GetAll()
    {

        List<Role> roles = _context.Role.ToList();
        return View("RoleList", roles);
    }

    [FeaturePermission("Permission", AccessLevel.View)]
    public IActionResult GetById(int id)
    {
        var role = _context.Role.Find(id);
        if (role == null)
        {
            return NotFound();
        }
         
        return View("Details", role);
    }

    [FeaturePermission("Permission", AccessLevel.Edit)]
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return View("Create", new Role());
        }
          
        var role = _context.Role.Find(id);
        if (role == null)
        {
            return NotFound();
        }
        
        return View(role);
    }

    [FeaturePermission("Permission", AccessLevel.Save)]
    [HttpPost]
    public IActionResult Save(Role role)
    {

        if (!ModelState.IsValid)
            return View(role.Id == 0 ? "Create" : "Edit", role);

        if (role.Id == 0)
            _context.Role.Add(role);
        else
            _context.Role.Update(role);


        _context.SaveChanges();
        return RedirectToAction("GetAll");
    }

    [FeaturePermission("Permission", AccessLevel.Delete)]
    public IActionResult Delete(int id)
    {
        var role = _context.Role.Find(id);
        if (role == null)
            return NotFound();

        _context.Role.Remove(role);
        _context.SaveChanges();
        return RedirectToAction("GetAll");
    }


    [FeaturePermission("Permission", AccessLevel.Delete)]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(string RoleName, string RoleDescription)
    {
        if (string.IsNullOrWhiteSpace(RoleName) || string.IsNullOrWhiteSpace(RoleDescription))
        {
            TempData["Error"] = "Role name aur description required hain.";
            return RedirectToAction("Index");
        }

        var newRole = new Role
        {
            RoleName = RoleName,
            RoleDescription = RoleDescription,
            DateCreated = DateTime.Now,
            CreatedBy = 2, // Ya session se lein
            Status = true,
        };

        _context.Role.Add(newRole);
        _context.SaveChanges();

        return RedirectToAction("GetAll");
    }
}
