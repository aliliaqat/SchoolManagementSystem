using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using PracticeSMSystem.Data.Enums;
using PracticeNewSms.Filters;
using PracticeSMSystem.Data.Database;
using PracticeSMSystem.Data.Models;
using System.Collections.Generic;


namespace PracticeNewSms.Controllers;

public class TeacherAttendanceController : Controller
{
    private readonly SMSDbContext _context;

    public TeacherAttendanceController(SMSDbContext context)
    {
        _context = context;
    }


    [FeaturePermission("TeacherAttendance", AccessLevel.View)]
    public IActionResult TeacherAttendanceList(int? TeacherId, int? DepartmentId, int? ClassRoomId)
    {

        var attendancelist = _context.Database.SqlQuery<TeacherAttendanceDto>($"Exec dbo.SP_GetTeacherAttendanceList @TeacherId ={TeacherId}, @DepartmentId = {DepartmentId}, @ClassRoomId ={ClassRoomId}").ToList();

        ViewBag.teachers = _context.teachers.ToList();
        ViewBag.Departments = _context.Departments.ToList();
        ViewBag.classroom = _context.classroom.ToList();
        /* ViewBag.SearchText = SearchText;*/                // for retaining input in search box

        return View(attendancelist);
    }


    [FeaturePermission("TeacherAttendance", AccessLevel.Details)]
    [HttpGet]
    public IActionResult Details(int Id)
    {
        var teacherattendance = _context.teacherAttendances.Include(a => a.ClassRoom).Include(a => a.Teacher).Include(a => a.Department).FirstOrDefault(a => a.Id == Id && a.IsDeleted == false);

        if (teacherattendance == null)
        {
            return NotFound();
        }
        return View(teacherattendance);
    }


    [FeaturePermission("TeacherAttendance", AccessLevel.Create)]
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.teachers = _context.teachers.ToList();
        ViewBag.Departments = _context.Departments.ToList();
        ViewBag.classroom = _context.classroom.ToList();
        ViewBag.AttendanceStatus = new List<SelectListItem>
        {
         new SelectListItem{ Value = "Present", Text = "Present"},
         new SelectListItem{Value  = "Absent", Text  = "Absent"},
         new SelectListItem{Value = "Leave", Text = "Leave"},
         new SelectListItem{Value = "Late", Text  = "Late"}
        };

        var model = new TeacherAttendance
        {
            TeacherAttendanceDate = DateTime.Now,
            UpDatedAt = DateTime.Now,
            IsDeleted = false,
        };
        return PartialView("_CreateEdit", model);
    }



    [FeaturePermission("TeacherAttendance", AccessLevel.Create)]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(TeacherAttendance teacherAttendance)
    {
        if (ModelState.IsValid)
        {
            var teacher = _context.teachers.FirstOrDefault(s => s.Id == teacherAttendance.TeacherId);
            if (teacher != null)
            {
                teacherAttendance.TFirstName = teacher.TFirstName;
                teacherAttendance.TLastName = teacher.TLastName;
            }

            teacherAttendance.TeacherAttendanceDate = DateTime.Now;
            teacherAttendance.IsDeleted = false;

            _context.teacherAttendances.Add(teacherAttendance);
            _context.SaveChanges();
            return Json(new { success = true, message = "Attendance Add Successfully" });
        }
        return Json(new { success = false, message = "Validation Fail", errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
    }


    [FeaturePermission("TeacherAttendance", AccessLevel.Edit)]
    [HttpGet]
    public IActionResult Edit(int Id)
    {
        var teacherattendance = _context.teacherAttendances.Include(t => t.ClassRoom).Include(t => t.Department).Include(t => t.Teacher).FirstOrDefault(t => t.Id == Id && t.IsDeleted == false);

        if (teacherattendance == null)
        {
            return NotFound();
        }
        ViewBag.teachers = _context.teachers.ToList();
        ViewBag.Departments = _context.Departments.ToList();
        ViewBag.classroom = _context.classroom.ToList();
        ViewBag.AttendanceStatus = new List<SelectListItem>
    {
        new SelectListItem{ Value = "Present", Text = "Present"},
        new SelectListItem{ Value = "Absent", Text = "Absent"},
        new SelectListItem{ Value = "Leave", Text = "Leave"},
        new SelectListItem{ Value = "Late", Text = "Late"}
    };

        return PartialView("_CreateEdit", teacherattendance);
    }


    [FeaturePermission("TeacherAttendance", AccessLevel.Edit)]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(TeacherAttendance teacherattendance)
    {
        //var tafromDb = _context.teacherAttendances.Include(t => t.ClassRoom).Include(t => t.Teacher).Include(t => t.Department).FirstOrDefault(t => t.Id == teacherattendance.Id && t.IsDeleted == false);
        var tafromDb = _context.teacherAttendances.FirstOrDefault(t => t.Id == teacherattendance.Id && t.IsDeleted == false);

        if (tafromDb == null)
        {
            return NotFound();
        }

        tafromDb.TeacherAttendanceDate = teacherattendance.TeacherAttendanceDate;
        tafromDb.TeacherAttendanceRemarks = teacherattendance.TeacherAttendanceRemarks;
        tafromDb.ClassRoomId = teacherattendance.ClassRoomId;
        tafromDb.DepartmentId = teacherattendance.DepartmentId;
        tafromDb.TeacherAttendanceStatus = teacherattendance.TeacherAttendanceStatus;

        tafromDb.UpDatedAt = DateTime.Now; // sirf audit field

        _context.SaveChanges();
        return Json(new { success = true, message = "Attendance Updated Successfully" });
    }


    [FeaturePermission("TeacherAttendance", AccessLevel.Delete)]
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var teacherattendance = _context.teacherAttendances.Include(a => a.ClassRoom).Include(a => a.Teacher).Include(a => a.Department).FirstOrDefault(a => a.Id == id && a.IsDeleted == false);

        if (teacherattendance == null)
        {
            return NotFound();
        }
        return View("Delete", teacherattendance);
    }


    [FeaturePermission("TeacherAttendance", AccessLevel.Delete)]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult ConfirmDelete(int Id)
    {
        var teacherattendance = _context.teacherAttendances.FirstOrDefault(a => a.Id == Id);

        if (teacherattendance == null)
        {
            return NotFound();
        }
        teacherattendance.IsDeleted = true;
        _context.SaveChanges();

        return Json(new { success = true, message = "Deleted Successfully" });
    }
}
