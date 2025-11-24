using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PracticeSMSystem.Data.Enums;
using PracticeNewSms.Filters;
using PracticeSMSystem.Data.Database;
using PracticeSMSystem.Data.Models;

namespace PracticeNewSms.Controllers;

public class ClassRoomController : Controller
{
    private readonly SMSDbContext _context;
    public ClassRoomController(SMSDbContext context)
    {
        _context = context;
    }

    [FeaturePermission("ClassRoom", AccessLevel.View)]
    public IActionResult Index()
    {
        var Classroom = _context.classroom.Include(c => c.Session).Include(c => c.Department).Include(c => c.TeacherClasses).ThenInclude(tc => tc.Teacher)
                                                                                                                        .Where(c => !c.IsDeleted).ToList();

        ViewBag.departmentlist = _context.Departments.Where(d => !d.IsDeleted).ToList();
        ViewBag.sessionlist = _context.Sessions.Where(s => !s.IsDeleted).ToList();
        ViewBag.teacherList = new MultiSelectList(_context.teachers.Where(t => !t.IsDeleted).ToList(), "Id", "TFirstName");

        return View(Classroom);
    }

    [FeaturePermission("ClassRoom", AccessLevel.Details)]
    public IActionResult Details(int id)
    {
        var classroom = _context.classroom.Include(c => c.Session).Include(c => c.Department).Include(c => c.TeacherClasses).ThenInclude(tc => tc.Teacher).FirstOrDefault(c => c.Id == id && !c.IsDeleted);
        if (classroom == null)
        {
            return NotFound();
        }
        return View(classroom);
    }


    [FeaturePermission("ClassRoom", AccessLevel.Create)]
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.departmentlist = _context.Departments.Where(d => !d.IsDeleted).ToList();
        ViewBag.sessionlist = _context.Sessions.Where(d => !d.IsDeleted).ToList();
        ViewBag.teacherList = new MultiSelectList(_context.teachers.Where(t => !t.IsDeleted).ToList(), "Id", "TFirstName");

        return View();
    }

    [FeaturePermission("ClassRoom", AccessLevel.Create)]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(ClassRoom classRoom, int[] SelectedTeacherIds)
    {
        if (ModelState.IsValid)
        {
            classRoom.CreatedOn = DateTime.Now;
            classRoom.UpdatedOn = DateTime.Now;
            classRoom.IsDeleted = false;
            classRoom.CreatedBy = 1;
            classRoom.UpdatedBy = 1;

            _context.classroom.Add(classRoom);
            _context.SaveChanges();


            if (SelectedTeacherIds != null && SelectedTeacherIds.Length > 0)
            {
                foreach (var teacherId in SelectedTeacherIds)
                {
                    var teacherClass = new TeacherClass
                    {
                        ClassRoomId = classRoom.Id,
                        TeacherId = teacherId
                    };
                    _context.TeacherClasses.Add(teacherClass);
                }
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        return View(classRoom);
    }


    [FeaturePermission("ClassRoom", AccessLevel.Edit)]
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var classroom = _context.classroom.Include(c => c.TeacherClasses).FirstOrDefault(c => c.Id == id && !c.IsDeleted);

        if (classroom == null)
        {
            return NotFound();
        }

        ViewBag.departmentlist = _context.Departments.Where(d => !d.IsDeleted).ToList();
        ViewBag.sessionlist = _context.Sessions.Where(s => !s.IsDeleted).ToList();
        ViewBag.teacherList = new MultiSelectList(_context.teachers.Where(t => !t.IsDeleted).ToList(), "Id", "TFirstName");

        return View(classroom);
    }

    [FeaturePermission("ClassRoom", AccessLevel.Edit)]
    [HttpPost]
    public IActionResult Edit(ClassRoom classRoom, int[] SelectedTeacherIds)
    {
        if (ModelState.IsValid)
        {
            var classRoomFromDb = _context.classroom.Include(c => c.TeacherClasses).FirstOrDefault(c => c.Id == classRoom.Id);

            if (classRoomFromDb == null)
            {
                return NotFound();
            }
            // 🔄 Update basic fields
            classRoomFromDb.ClassRName = classRoom.ClassRName;
            classRoomFromDb.DepartmentId = classRoom.DepartmentId;
            classRoomFromDb.SessionId = classRoom.SessionId;
            classRoomFromDb.Description = classRoom.Description;

            // 🕓 Audit trail
            classRoomFromDb.UpdatedOn = DateTime.Now;
            classRoomFromDb.UpdatedBy = 1;

            // 🔹 Add new relations
            //if (SelectedTeacherIds != null && SelectedTeacherIds.Length > 0)
            //{
            //    foreach (var teacherId in SelectedTeacherIds)
            //    {
            //        _context.TeacherClasses.Add(new TeacherClass
            //        {
            //            ClassRoomId = classRoom.Id,
            //            TeacherId = teacherId
            //        });
            //    }
            //}

            _context.TeacherClasses.RemoveRange(classRoomFromDb.TeacherClasses);

            if (SelectedTeacherIds != null && SelectedTeacherIds.Length > 0)
            {
                foreach (var teacherId in SelectedTeacherIds)
                {
                    _context.TeacherClasses.Add(new TeacherClass
                    {
                        ClassRoomId = classRoom.Id,
                        TeacherId = teacherId
                    });
                }
            }

            _context.SaveChanges();

            return RedirectToAction("Index"); 
        }
        ViewBag.departmentlist = _context.Departments.Where(d => !d.IsDeleted).ToList();
        ViewBag.sessionlist = _context.Sessions.Where(s => !s.IsDeleted).ToList();
        ViewBag.teacherList = new MultiSelectList(
            _context.teachers.Where(t => !t.IsDeleted).ToList(),
            "Id",
            "TFirstName",
            SelectedTeacherIds
        );

        return View(classRoom);
    }


    [FeaturePermission("ClassRoom", AccessLevel.Delete)]
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var Classroom = _context.classroom.FirstOrDefault(c => c.Id == id && !c.IsDeleted);

        if (Classroom == null)
        {
            return NotFound();
        }

        return View(Classroom);
    }


    [FeaturePermission("ClassRoom", AccessLevel.Delete)]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var Classroom = _context.classroom.FirstOrDefault(c => c.Id == id);

        if (Classroom == null)
        {
            return NotFound();
        }
        Classroom.IsDeleted = true;
        Classroom.DeletedOn = DateTime.Now;
        Classroom.DeletedBy = 1;

        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}
