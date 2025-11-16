using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using PracticeSMSystem.Data.Database;
using PracticeSMSystem.Data.Models;


namespace PracticeNewSms.Controllers;

public class AttendanceController : Controller
{
    private readonly SMSDbContext _context;

    public AttendanceController(SMSDbContext context)
    {
        _context = context;
    }

    public IActionResult AttendanceList(int? StudentId, int? ClassRoomId, int? SectionId, int? SubjectId, int? SessionId)
    {

        var attendancelist = _context.Database.SqlQuery<AttendanceDto>($"EXEC dbo.SP_GetAttendanceList @StudentId={StudentId}, @ClassRoomId = {ClassRoomId}, @SectionId = {SectionId}, @SubjectId = {SubjectId}, @SessionId = {SessionId} ").ToList();

        ViewBag.students = _context.Students.ToList();
        ViewBag.classroom = _context.classroom.ToList();
        ViewBag.sections = _context.sections.ToList();
        ViewBag.subjects = _context.subjects.ToList();
        ViewBag.sessions = _context.Sessions.ToList();

        return View(attendancelist);
    }

    [HttpGet]
    public IActionResult Detail(int Id)
    {
        var attendance = _context.Attendance.Include(a => a.Student).Include(a => a.ClassRoom).Include(a => a.Section).Include(a => a.Subject).FirstOrDefault(a => a.Id == Id);

        if (attendance == null)
        {
            return NotFound();
        }

        return View(attendance);
    }

    //[HttpGet]
    //public IActionResult Create()
    //{
    //    ViewBag.students = _context.Students.ToList();
    //    ViewBag.classroom = _context.classroom.ToList();
    //    ViewBag.sections = _context.sections.ToList();
    //    ViewBag.subjects = _context.subjects.ToList();

    //    ViewBag.AttendanceStatus = new List<SelectListItem>    /*AttendanceStatus static list for dropdown */
    //    {
    //     new SelectListItem { Value = "Present", Text = "Present" },
    //     new SelectListItem { Value = "Absent", Text = "Absent" },
    //     new SelectListItem { Value = "Leave", Text = "Leave" },
    //     new SelectListItem { Value = "Late", Text = "Late" }
    //    };

    //    var model = new Attendance
    //    {
    //        AttendanceDate = DateTime.Now,
    //        IsDeleted = false
    //    };

    //    return PartialView("_Create", model);
    //}

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.students = _context.Students.ToList();
        ViewBag.classroom = _context.classroom.ToList();
        ViewBag.sections = _context.sections.ToList();
        ViewBag.subjects = _context.subjects.ToList();

        ViewBag.AttendanceStatus = new List<SelectListItem>    /*AttendanceStatus static list for dropdown */
        {
         new SelectListItem { Value = "Present", Text = "Present" },
         new SelectListItem { Value = "Absent", Text = "Absent" },
         new SelectListItem { Value = "Leave", Text = "Leave" },
         new SelectListItem { Value = "Late", Text = "Late" }
        };

        var model = new Attendance
        {
            AttendanceDate = DateTime.Now,
            IsDeleted = false
        };

        return PartialView("_CreateEdit", model);
    }




    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Attendance attendance)
    {

        if (ModelState.IsValid)
        {
            attendance.AttendanceDate = DateTime.Now;
            attendance.CreatedAt = DateTime.Now;
            attendance.UpdatedAt = DateTime.Now;
            attendance.MarkedAt = DateTime.Now;
            attendance.VerifiedByAdminId = 1;
            attendance.IsHoliDay = false;
            attendance.IsDeleted = false;
            attendance.IsManualEntry = true;

            _context.Attendance.Add(attendance);
            _context.SaveChanges();

            return Json(new { success = true, message = "Attendance added successfully." });
        }

        return Json(new { success = false, message = "Validation failed.", errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
    }


    //[HttpGet]
    //public IActionResult Edit(int Id)
    //{
    //    var attendance = _context.Attendance.Include(a => a.Student).Include(a => a.ClassRoom).Include(a => a.Section).Include(a => a.Subject).FirstOrDefault(a => a.Id == Id);

    //    if (attendance == null)
    //    {
    //        return NotFound();
    //    }
    //    ViewBag.classroom = _context.classroom.ToList();
    //    ViewBag.sections = _context.sections.ToList();
    //    ViewBag.subjects = _context.subjects.ToList();

    //    return PartialView("_Edit", attendance);
    //}

    [HttpGet]
    public IActionResult Edit(int Id)
    {
        var attendance = _context.Attendance.Include(a => a.Student).Include(a => a.ClassRoom).Include(a => a.Section).Include(a => a.Subject).FirstOrDefault(a => a.Id == Id);

        if (attendance == null)
        {
            return NotFound();
        }
        ViewBag.students = _context.Students.ToList();
        ViewBag.classroom = _context.classroom.ToList();
        ViewBag.sections = _context.sections.ToList();
        ViewBag.subjects = _context.subjects.ToList();

        ViewBag.AttendanceStatus = new List<SelectListItem>    /*AttendanceStatus static list for dropdown */
        {
         new SelectListItem { Value = "Present", Text = "Present" },
         new SelectListItem { Value = "Absent", Text = "Absent" },
         new SelectListItem { Value = "Leave", Text = "Leave" },
         new SelectListItem { Value = "Late", Text = "Late" }
        };

        var model = new Attendance
        {
            AttendanceDate = DateTime.Now,
            IsDeleted = false
        };

        return PartialView("_CreateEdit", attendance);
    }




    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Attendance attendance)
    {
        var attendancefromDb = _context.Attendance.Include(a => a.Student).Include(a => a.ClassRoom).Include(a => a.Section).Include(a => a.Subject).FirstOrDefault(a => a.Id == attendance.Id);

        if (attendancefromDb == null)
        {
            return NotFound();
        }

        attendancefromDb.AttendanceStatus = attendance.AttendanceStatus;
        attendancefromDb.AttendanceRemarks = attendance.AttendanceRemarks;
        attendancefromDb.ClassRoomId = attendance.ClassRoomId;
        attendancefromDb.SectionId = attendance.SectionId;
        attendancefromDb.SubjectId = attendance.SubjectId;
        attendancefromDb.UpdatedAt = DateTime.Now;

        _context.SaveChanges();

        return Json(new { success = true, message = "Attendance Updated Successfully" });
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var attendance = _context.Attendance.Include(a => a.Student).Include(a => a.ClassRoom).Include(a => a.Section).Include(a => a.Subject).FirstOrDefault(a => a.Id == id && a.IsDeleted == false);

        if (attendance == null)
        {
            return NotFound();
        }
        return View("Delete", attendance);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult ConfirmDelete(int Id)
    {
        var attendance = _context.Attendance.FirstOrDefault(a => a.Id == Id);

        if (attendance == null)
        {
            return NotFound();
        }
        attendance.IsDeleted = true;
        _context.SaveChanges();


        return RedirectToAction("AttendanceList");
    }
}
