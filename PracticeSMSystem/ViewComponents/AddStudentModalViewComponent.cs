using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticeSMSystem.Data.Database;

namespace PracticeNewSms.ViewComponents;

public class AddStudentModalViewComponent : ViewComponent
{
    private readonly SMSDbContext _context;

    public AddStudentModalViewComponent(SMSDbContext context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke(int guardianId)
    {
        var guardian = _context.Guardians
            .Include(g => g.GuardianStudents)
            .ThenInclude(gs => gs.Student)
            .FirstOrDefault(g => g.Id == guardianId);

        if (guardian == null)
            return Content("Guardian not found.");

        // ✅ Student dropdown
        var studentList = _context.Students
            .Where(s => s.IsDeleted != true)
            .Select(s => new { s.Id, s.FullName })
            .ToList();

        ViewData["StudentList"] = new MultiSelectList(studentList, "Id", "FullName");

        return View(guardian);
    }
}
