using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticeSMSystem.Data;
using PracticeSMSystem.Data.Database;
using PracticeSMSystem.Data.Models;

namespace PracticeSMSystem.Controllers;

public class StudentController : Controller
{
    private readonly SMSDbContext _context;

    public StudentController(SMSDbContext context)
    {
        _context = context;
    }

    //public IActionResult StudentList(int classId)
    //{
    //    var classInfo  = _context.classroom.Include(c => c.Session).Include(c => c.Section).FirstOrDefault(c => c.Id == classId);
    //    var students = _context.Database.SqlQuery<StudentList>($"EXEC dbo.Sp_GetStudetnList {classId}").ToList();

    //    ViewBag.ClassInfo = classInfo;
    //    TempData["ClassId"] = classId;


    //    ViewBag.classlist = new SelectList(_context.classroom, "Id", "ClassRName");
    //    ViewBag.sectionlist = new SelectList(_context.sections, "Id", "SectionName");


    //    return View(students);
    //}
    public IActionResult StudentList(int? classId = null)
    {
        object? classInfo = null;
        if (classId.HasValue && classId.Value > 0)
        {
            classInfo = _context.classroom.Include(c => c.Session).Include(c => c.Section).FirstOrDefault(c => c.Id == classId.Value);
        }

        List<StudentList> students;
        if (classId.HasValue && classId.Value > 0)
        {
            students = _context.Database.SqlQuery<StudentList>($"EXEC dbo.Sp_GetStudetnList {classId.Value}, NULL").ToList();
        }
        else
        {
            students = _context.Database.SqlQuery<StudentList>($"EXEC dbo.Sp_GetStudetnList NULL, NULL").ToList();
        }

        ViewBag.ClassInfo = classInfo;
        TempData["ClassId"] = classId;

        ViewBag.classlist = new SelectList(_context.classroom, "Id", "ClassRName");
        ViewBag.sectionlist = new SelectList(_context.sections, "Id", "SectionName");

        return View(students);
    }


    public IActionResult Details(int id, string section)
    {
        var student = _context.Students.Include(s => s.ClassRoom).FirstOrDefault(s => s.Id == id && s.IsDeleted != true);

        if (student == null)
        {
            return NotFound();
        }

        TempData["ClassId"] = student.ClassRoomId;
        ViewBag.Section = section;
        //ViewBag.ShowDetails = TempData["ShowDetails"] != null && (bool)TempData["ShowDetails"];

        return View(student);
    }



    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.ClassList = new SelectList(_context.classroom, "ClassRoomId", "ClassName");
        ViewBag.SectionList = new SelectList(_context.sections, "SectionId", "SectionName");

        var model = new Student
        {
            DateOfBirth = DateTime.Now, 
            AddmissionDate = DateTime.Now,
             IsDeleted = false
        };

        return PartialView("_CreateModal", model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Student student)
    {
        if (ModelState.IsValid)
        {
            student.AddmissionDate = DateTime.Now;
            student.IsDeleted = false;
            _context.Students.Add(student);
            _context.SaveChanges();

            return RedirectToAction(nameof(StudentList));
        }
        return PartialView("_CreateModal", student);
    }


    [HttpGet]
    public IActionResult Edit(int id, string section)
    {
        var student = _context.Students.FirstOrDefault(s => s.Id == id && s.IsDeleted != true);

        if (student == null)
        {
            return NotFound();
        }

        ViewBag.Section = section; // ✅ do section identify
        ViewBag.classlist = new SelectList(_context.classroom, "Id", "ClassRName");
        ViewBag.GenderList = new SelectList(new[] { "Male", "Female", "Other" }, student.Gender);

        return View(student);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Student student, string section)
    {
        var studentFromDb = _context.Students.FirstOrDefault(s => s.Id == student.Id && s.IsDeleted != true);
        if (studentFromDb == null)
        {
            return NotFound();
        }

        // 🔹 Section کے مطابق متعلقہ فیلڈز اپڈیٹ کریں
        switch (section)
        {
            case "General":
                studentFromDb.StudentFName = student.StudentFName;
                studentFromDb.StudentLName = student.StudentLName;
                studentFromDb.Gender = student.Gender;
                studentFromDb.DateOfBirth = student.DateOfBirth;
                break;

            case "Student":
                studentFromDb.Status = student.Status;
                studentFromDb.SpecialInstruction = student.SpecialInstruction;
                studentFromDb.ClassRoomId = student.ClassRoomId;
                break;

            case "Contact":
                studentFromDb.Email = student.Email;
                studentFromDb.PhoneNo = student.PhoneNo;
                studentFromDb.Address = student.Address;
                break;

            case "Activity":
                studentFromDb.Activity = student.Activity;
                break;

            default:
                return BadRequest("Invalid section name");
        }

        _context.SaveChanges();

        return RedirectToAction("Details", new { id = student.Id });
    }



    [HttpPost]
    public IActionResult SaveInstruction(int StudentId, string InstructionText)
    {
        var student = _context.Students.Find(StudentId);

        if (student == null)
        {
            return NotFound();
        }

        student.SpecialInstruction = InstructionText;
        _context.SaveChanges();

        return RedirectToAction(nameof(StudentList));
    }




    [HttpGet]
    public IActionResult Delete(int id)
    {
        var student = _context.Students.FirstOrDefault(s => s.Id == id && s.IsDeleted != true);

        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var student = _context.Students.FirstOrDefault(s => s.Id == id);

        if (student == null)
        {
            return NotFound();
        }

        student.IsDeleted = true;



        _context.SaveChanges();

        return RedirectToAction("StudentList");
    }
}
