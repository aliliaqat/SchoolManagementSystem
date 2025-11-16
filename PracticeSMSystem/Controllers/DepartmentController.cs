using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticeSMSystem.Data.Database;
using PracticeSMSystem.Data.Models;
namespace PracticeNewSms.Controllers;

public class DepartmentController : Controller
{
    private readonly SMSDbContext _context;

    public DepartmentController(SMSDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var departments = _context.Departments.Include(d => d.Head).Where(d => !d.IsDeleted).ToList();

        ViewBag.StaffList = _context.Staff.Where(s => !s.IsDeleted).ToList();
        return View(departments);
    }

    public IActionResult Details(int id)
    {
        //ViewBag.StaffList = _context.Staff.Where(s => !s.IsDeleted).ToList();

        var department = _context.Departments.Include(d => d.Head).FirstOrDefault(d => d.Id == id && !d.IsDeleted);

        if (department == null)
        {
            return NotFound();
        }

        return View (department);
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.StaffList = _context.Staff.Where(s => !s.IsDeleted).ToList();

        return View();
    }

    [HttpPost]
    public IActionResult Create(Department department)
    {
        if (ModelState.IsValid)
        {

            department.CreatedOn = DateTime.Now;
            department.UpdatedOn = DateTime.Now;
            department.IsDeleted = false;
            department.CreatedBy = 1;
            department.UpdatedBy = 1;

            _context.Departments.Add(department);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        return View(nameof(Index));
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var department = _context.Departments.FirstOrDefault(d => d.Id == id && !d.IsDeleted);

        if (department == null)
        {
            return NotFound();
        }
        ViewBag.StaffList = _context.Staff.Where(s => !s.IsDeleted).ToList();

        //ViewBag.StaffList = _context.Staff.Where(s => !s.IsDeleted).Select(s => new

        //{
        //    s.Id,
        //    FullName = s.FirstName + " " + s.LastName
        //})
        //    .ToList();

        return View(department);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Department department)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.StaffList = _context.Staff.Where(s => !s.IsDeleted).ToList();

            return View(department);
        }
        var existing = _context.Departments.FirstOrDefault(d => d.Id == department.Id);

        if (existing == null)
        {
            return NotFound();
        }

        existing.DName = department.DName;
        existing.DDescription = department.DDescription;
        existing.DepHeadId = department.DepHeadId;
        existing.UpdatedOn = DateTime.Now;
        existing.UpdatedBy = 1;

        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var department = _context.Departments.FirstOrDefault(d => d.Id == id && !d.IsDeleted);

        if (department == null)
        {
            return NotFound();
        }

        return View(department);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var department = _context.Departments.FirstOrDefault(d => d.Id == id);
        if (department == null)
        { 
            return NotFound();
        }
        department.IsDeleted = true;
        department.DeletedOn = DateTime.Now;
        department.DeletedBy = 1;

        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}