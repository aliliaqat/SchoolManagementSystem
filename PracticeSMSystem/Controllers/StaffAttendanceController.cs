using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using PracticeSMSystem.Data.Database;
using PracticeSMSystem.Data.Models;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;


namespace PracticeNewSms.Controllers;

public class StaffAttendanceController : Controller
{
    private readonly SMSDbContext _context;

    public StaffAttendanceController(SMSDbContext context)
    {
        _context = context;
    }

    public IActionResult StaffAttendanceList(int? StaffId, int? DepartmentId)
    {
        var staffattendancelist = _context.Database.SqlQuery<StaffAttendanceListDto>($"EXEC dbo.Sp_GetStaffAttendanceList @StaffId ={StaffId}, @DepartmentId ={DepartmentId}").ToList();

        ViewBag.staff = _context.Staff.ToList();
        ViewBag.Departments = _context.Departments.ToList();

        return View(staffattendancelist);
    }

    public IActionResult Detail(int Id)
    {
        var staffattendance = _context.staffAttendances.Include(s => s.Staff).Include(s => s.Department).FirstOrDefault(s => s.Id == Id && s.IsDeleted == false);
        if (staffattendance == null)
        {
            return NotFound();
        }

        return View(staffattendance);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.staff = _context.Staff.ToList();
        ViewBag.Departments = _context.Departments.ToList();
        ViewBag.AttendanceStatus = new List<SelectListItem>
    {
        new SelectListItem { Value ="Present", Text ="Present"},
        new SelectListItem { Value ="Absent", Text="Absent"},
        new SelectListItem { Value="Late", Text="Late"},
        new SelectListItem { Value="Leave", Text="Leave"}
    };

        var model = new StaffAttendance
        {
            AttendanceDate = DateTime.Now,
            CreatedOn = DateTime.Now,
            UpdatedOn = DateTime.Now,
            IsDeleted = false,
        };

        return PartialView("_CreateEdit", model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(StaffAttendance staffAttendance)
    {
        if (ModelState.IsValid)
        {
            var staff = _context.Staff.FirstOrDefault(s => s.Id == staffAttendance.StaffId);
            if (staff != null)
            {
                staffAttendance.FirstName = staff.FirstName;
                staffAttendance.LastName = staff.LastName;
            }
            staffAttendance.CreatedOn = DateTime.Now;
            staffAttendance.UpdatedOn = DateTime.Now;
            staffAttendance.DeletedOn = DateTime.Now;
            staffAttendance.MarkedAt = DateTime.Now;
            staffAttendance.IsDeleted = false;
            staffAttendance.CreatedBy = 1;
            staffAttendance.UpdatedBy = 1;

            _context.staffAttendances.Add(staffAttendance);
            _context.SaveChanges();

            return Json(new { success = true, message = "Attendance Add Successfully" });
        }
        return Json(new { success = false, message = "Validation Fail", errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
    }

    [HttpGet]
    public IActionResult Edit(int Id)
    {
        var staffattendance = _context.staffAttendances.Include(s => s.Staff).Include(s => s.Department).FirstOrDefault(s => s.Id == Id && s.IsDeleted == false);

        if (staffattendance == null)
        {
            return NotFound();
        }
           
        ViewBag.staff = _context.Staff.ToList();
        ViewBag.Departments = _context.Departments.ToList();

        ViewBag.AttendanceStatus = new List<SelectListItem>
    {
        new SelectListItem { Value ="Present", Text ="Present"},
        new SelectListItem { Value ="Absent", Text="Absent"},
        new SelectListItem { Value="Late", Text="Late"},
        new SelectListItem { Value="Leave", Text="Leave"}
    };

        return PartialView("_CreateEdit", staffattendance);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(StaffAttendance staffAttendance)
    {
        var stafromDb = _context.staffAttendances.Include(s => s.Staff).Include(s => s.Department).FirstOrDefault(s => s.Id == staffAttendance.Id && s.IsDeleted == false);
        if (stafromDb == null)
        {
            return NotFound();
        }

        stafromDb.DepartmentId = staffAttendance.DepartmentId;
        stafromDb.AttendanceStatus = staffAttendance.AttendanceStatus;
        stafromDb.AttendanceRemarks = staffAttendance.AttendanceRemarks;
        stafromDb.CreatedOn = DateTime.Now;
        stafromDb.UpdatedOn = DateTime.Now;
        stafromDb.DeletedOn = DateTime.Now;

        _context.SaveChanges();
        return Json(new { success = true, message = "Attendance Updated Successfully" });
    }

    [HttpGet]
    public IActionResult Delete(int Id)
    {
        var staffattendance = _context.staffAttendances.Include(s => s.Staff).Include(s => s.Department).FirstOrDefault(s => s.Id == Id && s.IsDeleted == false);
        if (staffattendance == null)
        {
            return NotFound();
        }

        return View("Delete", staffattendance);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult ConfirmDelete(int Id)
    {
        var staffattendance = _context.staffAttendances.FirstOrDefault(s => s.Id == Id);

        if (staffattendance == null)
        {
            return NotFound();
        }
        staffattendance.IsDeleted = true;
        _context.SaveChanges();
        return RedirectToAction("StaffAttendanceList");
    }
}
