using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticeSMSystem.Data.Database;
using PracticeSMSystem.Data.Models;

namespace PracticeSMSystem.Controllers;

public class GuardianController : Controller
{
    private readonly SMSDbContext _context;

    public GuardianController(SMSDbContext context)
    {
        _context = context;
    }

    public IActionResult List(int Id)
    {
        if (Id == 0)
        {
            var guardian = _context.Database.SqlQuery<GuardianListDto>($"Exec dbo.Sp_GetGuardianList").ToList();
            ViewBag.StudentList = _context.Students.Where(s => s.IsDeleted == false).ToList();

            return View("GuardianList", guardian);
        }
        else
        {
            List<int> gIds = _context.GuardianStudents.Where(s => s.StudentId == Id).Select(d => d.GuardianId).ToList();
            var guardian = _context.GuardianStudents.Where(g => gIds.Contains(g.GuardianId)).Include(s => s.Guardian).Include(g => g.Student).ToList();
            return View("Details", guardian);
        }
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.StudentList = _context.Students.Where(s => s.IsDeleted == false).ToList();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Guardian guardian, int? StudentId, string? Relationship)
    {
        if (ModelState.IsValid)
        {
            _context.Guardians.Add(guardian);
            _context.SaveChanges();

            if (StudentId.HasValue && StudentId.Value > 0)
            {
                var guardianStudent = new GuardianStudent
                {
                    GuardianId = guardian.Id,
                    StudentId = StudentId.Value,
                    Relationship = Relationship
                };
                _context.GuardianStudents.Add(guardianStudent);
                _context.SaveChanges();

                return RedirectToAction("Details", new { Id = StudentId.Value });
            }


            if (guardian.SelectedStudentIds != null && guardian.SelectedStudentIds.Any())
            {
                foreach (var id in guardian.SelectedStudentIds)
                {
                    var guardianStudent = new GuardianStudent
                    {
                        GuardianId = guardian.Id,
                        StudentId = id
                    };
                    _context.GuardianStudents.Add(guardianStudent);
                }
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(List));
        }
        return View(guardian);
    }



    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddStudents(int guardianId, List<int> SelectedStudentIds)
    {
        if (SelectedStudentIds != null && SelectedStudentIds.Any())
        {
            var existingStu = _context.GuardianStudents.Where(gs => gs.GuardianId == guardianId).Select(gs => gs.StudentId);

            var guardian = _context.Guardians.Find(guardianId);

            foreach (var id in SelectedStudentIds.Where(id => !existingStu.Contains(id)))
            {
                var guardianStudent = new GuardianStudent
                {
                    GuardianId = guardianId,
                    StudentId = id,
                    //Relationship = guardian?.GRelationship
                };

                _context.GuardianStudents.Add(guardianStudent);
            }

            _context.SaveChanges();
        }

        return RedirectToAction(nameof(List));

    }


    public IActionResult StudentGuardian(int studentId)
    {
        var selectedStudent = _context.Students.FirstOrDefault(s => s.Id == studentId && s.IsDeleted != true);

        if (selectedStudent == null)
        {
            return NotFound();
        }

        var guardianStudents = _context.GuardianStudents.Include(gs => gs.Guardian).Include(gs => gs.Student)
                            .Where(gs => gs.StudentId == studentId && gs.Guardian.IsDeleted != true).ToList();

        ViewBag.SelectedStudent = selectedStudent;
        ViewBag.SelectedStudentId = selectedStudent.Id;

        // ViewData flag for showing "Attach Guardian"
        ViewData["ShowStudentDropdown"] = false;

        return View("StudentGuardian", guardianStudents);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var guardian = _context.Guardians.Include(g => g.GuardianStudents).ThenInclude(gs => gs.Student).FirstOrDefault(g => g.Id == id && g.IsDeleted != true);

        if (guardian == null)
        {
            return NotFound();
        }

        guardian.SelectedStudentIds = guardian.GuardianStudents.Select(gs => gs.StudentId).ToList();
        ViewBag.StudentList = _context.Students.Where(s => s.IsDeleted == false).ToList();

        return View(guardian);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Guardian guardian)
    {
        var guardianDb = _context.Guardians.Include(g => g.GuardianStudents).FirstOrDefault(g => g.Id ==guardian.Id && g.IsDeleted != true);
        if (guardian == null)
        {
            return NotFound();
        }

        guardianDb.GFirstName = guardian.GFirstName;
        guardianDb.GLastName  = guardian.GLastName;
        guardianDb.GRelationship = guardian.GRelationship;
        guardianDb.GPhone = guardian.GPhone;
        guardianDb.GAddress = guardian.GAddress;
        guardianDb.GEmail = guardian.GEmail;

        guardianDb.GuardianStudents.Clear();

        if (guardian.SelectedStudentIds != null)
        {
            foreach (var studentId in guardian.SelectedStudentIds)
            {
                guardianDb.GuardianStudents.Add(new GuardianStudent
                {
                    GuardianId = guardianDb.Id,
                    StudentId = studentId
                });
            }
        }

        _context.SaveChanges();

        return RedirectToAction("Details", new { id = guardianDb.Id });
    }



    public IActionResult Details(int id)
    {
        var guardian = _context.Guardians.Include(g => g.GuardianStudents).ThenInclude(gs => gs.Student).FirstOrDefault(g => g.Id == id && g.IsDeleted != true);

        if (guardian == null)
        {
            return NotFound();
        }

        return View(guardian);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var guardian = _context.Guardians.FirstOrDefault(g => g.Id == id && g.IsDeleted != true);

        if (guardian == null)
        {
            return NotFound();
        }

        return View(guardian);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var guardian = _context.Guardians.FirstOrDefault(g => g.Id == id);

        if (guardian == null)
        {
            return NotFound();
        }

        guardian.IsDeleted = true;
        _context.SaveChanges();

        return RedirectToAction("List");
    }
}




