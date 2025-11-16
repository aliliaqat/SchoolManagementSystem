using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PracticeSMSystem.Data.Database;
using PracticeSMSystem.Data.Models;

namespace PracticeNewSms.Controllers;

public class SubjectController : Controller
{
    private readonly SMSDbContext _context;

    public SubjectController(SMSDbContext context)
    {
        _context = context;
    }

    public IActionResult SubjectList()
    {
        var Subject = _context.subjects.Include(s => s.ClassRoom).Include(s => s.Department).Include(s => s.Teacher).Where(s => !s.IsDeleted).ToList();

        ViewBag.teacherlist = _context.teachers.Where(t => !t.IsDeleted).ToList();
        ViewBag.departmentlist = _context.Departments.Where(d => !d.IsDeleted).ToList();
        ViewBag.classlist = _context.classroom.Where(c => !c.IsDeleted).ToList();


        return View(Subject);
    }

    public IActionResult Details(int id)
    {
        var Subject = _context.subjects.Include(s => s.Teacher).Include(s => s.Department).Include(s => s.ClassRoom).FirstOrDefault(s => s.Id == id && !s.IsDeleted);

        if (Subject == null)
        {
            return NotFound();
        }

        string tfname = "FullName";
        ViewBag.teacherlist = new SelectList(_context.teachers, "Id", tfname);
        ViewBag.departmentlist = new SelectList(   _context.Departments, "id", "DName");
        ViewBag.classlist = new SelectList(_context.classroom, "id", "ClassRName");

        return View(Subject);
    }


    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.teacherlist = _context.teachers.Where(t => !t.IsDeleted).ToList();
        ViewBag.departmentlist = _context.Departments.Where(d => !d.IsDeleted).ToList();
        ViewBag.classlist = _context.classroom.Where(c => !c.IsDeleted).ToList();

        return View();
    }

    [HttpPost]
    public IActionResult Create(Subject subject)
    {
        if (ModelState.IsValid)
        {
            subject.CreatedOn = DateTime.Now;
            subject.UpdatedOn = DateTime.Now;
            subject.IsDeleted = false;
            subject.CreatedBy = 1;
            subject.UpdatedBy = 1;

            _context.subjects.Add(subject);
            _context.SaveChanges();
            return RedirectToAction(nameof(SubjectList));
        }

        ViewBag.teacherlist = _context.teachers.Where(t => !t.IsDeleted).ToList();
        ViewBag.departmentlist = _context.Departments.Where(d => !d.IsDeleted).ToList();
        ViewBag.classlist = _context.classroom.Where(c => !c.IsDeleted).ToList();

        return View(subject);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var Subject = _context.subjects.FirstOrDefault(s => s.Id == id && !s.IsDeleted);

        if (Subject == null)
        {
            return NotFound();
        }


        ViewBag.teacherlist = _context.teachers.Where(t => !t.IsDeleted).ToList();
        ViewBag.departmentlist = _context.Departments.Where(d => !d.IsDeleted).ToList();
        ViewBag.classlist = _context.classroom.Where(c => !c.IsDeleted).ToList();

        return View(Subject);
    }

    [HttpPost]
    public IActionResult Edit(Subject subject)
    {
        if (ModelState.IsValid)
        {
            var Subfromdb = _context.subjects.Include(s => s.Teacher).Include(s => s.Department).Include(s => s.ClassRoom).FirstOrDefault(s => s.Id == subject.Id);

            if (Subfromdb == null) 
            {
            return NotFound();
            }

            Subfromdb.SubjectName = subject.SubjectName;
            Subfromdb.SubjectCode = subject.SubjectCode;
            Subfromdb.TeacherId  = subject.TeacherId;
            Subfromdb.DepartmentId = subject.DepartmentId;
            Subfromdb.ClassRoomId = subject.ClassRoomId;

            Subfromdb.UpdatedOn = DateTime.Now;
            Subfromdb.UpdatedBy = 1;

            _context.SaveChanges();

            return RedirectToAction(nameof(SubjectList));
        }

        ViewBag.teacherlist = _context.teachers.Where(t => !t.IsDeleted).ToList();
        ViewBag.departmentlist = _context.Departments.Where(d => !d.IsDeleted).ToList();
        ViewBag.classlist = _context.classroom.Where(c => !c.IsDeleted).ToList();

        return View(subject);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var Subject = _context.subjects.FirstOrDefault(s => s.Id == id && !s.IsDeleted);

        if (Subject == null)
        {
            return NotFound();
        }
        return View(Subject);
    }

    [HttpPost]
    public IActionResult DeleteConformed(int id) 
    {
     var Subject =_context.subjects.FirstOrDefault(s => s.Id == id && !s.IsDeleted);

        if (Subject == null) { 
        return NotFound();
        }

        Subject.IsDeleted = true;
        Subject.DeletedOn = DateTime.Now;
        Subject.DeleteBy = 1;

        _context.SaveChanges(); 

        return RedirectToAction(nameof(SubjectList));
    }
}