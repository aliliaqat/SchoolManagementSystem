using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticeSMSystem.Data.Database;
using PracticeSMSystem.Data.Models;

namespace PracticeSMSystem.Controllers;

public class EnrolementController : Controller
{
    private readonly SMSDbContext _context;

    public EnrolementController(SMSDbContext context)
    {
        _context = context;
    }
    public IActionResult ClassesList()
    {
        var ClassRoom = _context.Database.SqlQuery<ClassDto>($"Exec dbo.Sp_GetClassesList").ToList();

        return View(ClassRoom);
    }
}
