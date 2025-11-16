namespace PracticeNewSms.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticeSMSystem.Data.Database;

public class CreateGuardianModalViewComponent : ViewComponent
{
    private readonly SMSDbContext _context;

    public CreateGuardianModalViewComponent(SMSDbContext context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke()
    {
        
        var studentList = _context.Students
            .Where(s => s.IsDeleted != true)
            .Select(s => new { s.Id, s.FullName })
            .ToList();

        ViewData["StudentList"] = new MultiSelectList(studentList, "Id", "FullName");

        
        return View();
    }
}
