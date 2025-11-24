using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticeSMSystem.Data.Enums;
using PracticeNewSms.Filters;
using PracticeSMSystem.Data.Database;
using PracticeSMSystem.Data.Models;
using static System.Collections.Specialized.BitVector32;

namespace PracticeNewSms.Controllers;

public class TeacherController : Controller
{
    private readonly SMSDbContext _context;

    public TeacherController(SMSDbContext context)
    {
        _context = context;
    }

    [FeaturePermission("Teacher", AccessLevel.View)]
    public IActionResult TeacherList()
    {
        var teacherList = _context.Database.SqlQuery<TeacherDto>($"EXEC dbo.Sp_GetAllTeacherList NULL, NULL").ToList();
       
        return View(teacherList);
    }


    [FeaturePermission("Teacher", AccessLevel.Create)]
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.departmentlist = new SelectList(_context.Departments.Where(d => !d.IsDeleted), "Id", "DName");
        ViewBag.ClassList = new SelectList(_context.classroom.Where(c => !c.IsDeleted).ToList(), "Id", "ClassRName");
        ViewBag.GenderList = new SelectList(new[] { "Male", "Female", "Other" });

        var model = new Teacher
        {
            HireDate = DateTime.Now,
            DateOfBirth = DateTime.Now,
            IsDeleted = false
        };
        return PartialView("_Create", model);
    }


    [FeaturePermission("Teacher", AccessLevel.Create)]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Teacher teacher)
    {
        if (ModelState.IsValid)
        {
            teacher.HireDate = DateTime.Now;
            teacher.IsDeleted = false;
            teacher.CreatedOn = DateTime.Now;
            teacher.CreatedBy = 1;
            teacher.UpdatedOn = DateTime.Now;
            teacher.UpdatedBy = 1;

            _context.teachers.Add(teacher);
            _context.SaveChanges();

            if (teacher.ClassRoomId > 0)
            {
                var teacherClass = new TeacherClass
                {
                    TeacherId = teacher.Id,
                    ClassRoomId = teacher.ClassRoomId
                };
                _context.TeacherClasses.Add(teacherClass);
                _context.SaveChanges();
            }
            return Json(new { success = true, message = "Teacher added successfully." });
        }

        return Json(new { success = false, message = "Validation failed.", errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
    }


    [FeaturePermission("Teacher", AccessLevel.Edit)]
    [HttpGet]
    public IActionResult Edit(int id, string section)
    {
        var teacher = _context.teachers.Include(t => t.TeacherClasses).ThenInclude(tc => tc.ClassRoom).FirstOrDefault(t => t.Id == id);

        if (teacher == null)
        {
            return NotFound();
        }

        ViewBag.Section = section ?? "General"; // identify section
        ViewBag.DepartmentList = new SelectList(_context.Departments.Where(d => d.IsDeleted == false).ToList(), "Id", "DName", teacher.DepartmentId);
        var allClasses = _context.classroom.Where(c => !c.IsDeleted).ToList();
        ViewBag.ClassList = new MultiSelectList(
            allClasses, "Id", "ClassRName",
            teacher.TeacherClasses.Select(tc => tc.ClassRoomId).ToList());
        ViewBag.GenderList = new SelectList(new[] { "Male", "Female", "Other" }, teacher.Gender);

        return PartialView("_Edit", teacher);
    }


    [FeaturePermission("Teacher", AccessLevel.Edit)]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Teacher teacher, string section)
    {
        var teacherFromDb = _context.teachers.Include(t => t.TeacherClasses).FirstOrDefault(t => t.Id == teacher.Id);

        if (teacherFromDb == null)
        {
            return NotFound();
        }

        switch (section)
        {
            case "General":
                teacherFromDb.TFirstName = teacher.TFirstName;
                teacherFromDb.TLastName = teacher.TLastName;
                teacherFromDb.Gender = teacher.Gender;
                teacherFromDb.DateOfBirth = teacher.DateOfBirth;
                break;

            case "Teacher":
                teacherFromDb.Qualification = teacher.Qualification;
                teacherFromDb.HireDate = teacher.HireDate;
                teacherFromDb.Status = teacher.Status;
                teacherFromDb.Salary = teacher.Salary;
                teacherFromDb.DepartmentId = teacher.DepartmentId;

                // 🔥 FIX START
                _context.TeacherClasses.RemoveRange(teacherFromDb.TeacherClasses);   // delete old
                teacherFromDb.TeacherClasses = new List<TeacherClass>();             // reset list
                                                                                     // 🔥 FIX END

                if (teacher.SelectedClassIds != null && teacher.SelectedClassIds.Any())
                {
                    foreach (var classId in teacher.SelectedClassIds)
                    {
                        teacherFromDb.TeacherClasses.Add(new TeacherClass
                        {
                            TeacherId = teacherFromDb.Id,
                            ClassRoomId = classId
                        });
                    }
                }
                break;


            case "Contact":
                teacherFromDb.Email = teacher.Email;
                teacherFromDb.PhoneNo = teacher.PhoneNo;
                teacherFromDb.Address = teacher.Address;
                break;

            case "Activity":
                teacherFromDb.Activity = teacher.Activity;
                break;

            default:
                return BadRequest("Invalid section name");
        }

        _context.SaveChanges();

        return Json(new { success = true, message = "Teacher updated successfully." });
    }


    [FeaturePermission("Teacher", AccessLevel.Details)]
    [HttpGet]
    public IActionResult Details(int id, string activeTab = "General")
    {
        var teacher = _context.teachers.Include(t => t.Department).Include(t => t.TeacherClasses).ThenInclude(tc => tc.ClassRoom).FirstOrDefault(t => t.Id == id);
        if (teacher == null)
        {
            return NotFound();
        }
        ViewBag.ActiveTab = activeTab;
        return View("Detail", teacher);
    }


    [FeaturePermission("Teacher", AccessLevel.Delete)]
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var teacher = _context.teachers.Include(t => t.Department).Include(t => t.TeacherClasses).ThenInclude(tc => tc.ClassRoom).FirstOrDefault(t => t.Id == id);
        if (teacher == null)
        {
            return NotFound();
        }
            
        return View("Delete", teacher);
    }


    [FeaturePermission("Teacher", AccessLevel.Delete)]
    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        var teacher = _context.teachers.Include(t => t.TeacherClasses).FirstOrDefault(t => t.Id == id);
        if (teacher != null)
        {
            teacher.IsDeleted = true;
            _context.SaveChanges();
        }
        var teacherList = _context.Database.SqlQuery<TeacherDto>($"EXEC dbo.Sp_GetAllTeacherList NULL, NULL").ToList();
       
        return PartialView("TeacherList", teacherList);
    }
}

