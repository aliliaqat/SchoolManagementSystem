using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PracticeSMSystem.Data.Database;
using PracticeSMSystem.Data.Models;

namespace PracticeNewSms.Controllers;

public class SessionController : Controller
{
    private readonly SMSDbContext _context;

    public SessionController(SMSDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var session = _context.Sessions.Include(s => s.classroom).Where(s => !s.IsDeleted).ToList();

        ViewBag.ClassRList = _context.classroom.Where(sc => !sc.IsDeleted).ToList();
        return View(session);
    }

    public IActionResult Details(int Id)
    {
        var session = _context.Sessions.Include(s => s.classroom).FirstOrDefault(s => s.Id == Id && !s.IsDeleted);

        if (session == null)
        {
            return NotFound();
        }

        session.classroom = session.classroom.Where(c => !c.IsDeleted).ToList();

        return View(session);
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.ClassRList = _context.classroom.Where(sc => !sc.IsDeleted).ToList();
        return View();
    }

    [HttpPost]
    public IActionResult Create(Session session)
    {
        if (ModelState.IsValid)
        {
            session.CreatedOn = DateTime.Now;
            session.UpdatedOn = DateTime.Now;
            session.IsDeleted = false;
            session.CreatedBy = 1;
            session.UpdatedBy = 1;

            _context.Sessions.Add(session);
            _context.SaveChanges();

            // Assign selected classrooms
            if (session.SelectedClassRoomIds != null && session.SelectedClassRoomIds.Any())
            {
                var schoolClasses = _context.classroom.Where(c => session.SelectedClassRoomIds.Contains(c.Id)).ToList();



                foreach (var sc in schoolClasses)
                {
                    sc.SessionId = session.Id; // relation establish karna
                }

                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        // ⚠️ zaroori hai: agar ModelState invalid ho to list phir se load karo
        ViewBag.SchoolClassList = _context.classroom.Where(sc => !sc.IsDeleted).ToList();



        return View(session);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        // Include classrooms
        var session = _context.Sessions.Include(s => s.classroom).FirstOrDefault(s => s.Id == id && !s.IsDeleted);



        if (session == null)
        {
            return NotFound();
        }

        // SelectedClassRoomIds me current assigned classes fill karna
        session.SelectedClassRoomIds = session.classroom?.Where(c => !c.IsDeleted).Select(c => c.Id).ToList() ?? new List<int>();


        // All classes for dropdown
        ViewBag.ClassRList = _context.classroom.Where(sc => !sc.IsDeleted).ToList();



        // All sessions for dropdown
        ViewBag.SessionList = _context.Sessions.Where(s => !s.IsDeleted).ToList();



        return View(session);
    }



    [HttpPost]
    public IActionResult Edit(Session session)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.ClassRList = _context.classroom.Where(sc => !sc.IsDeleted).ToList();
            ViewBag.SessionList = _context.Sessions.Where(s => !s.IsDeleted).ToList();
            return View(session);
        }

        // Load existing session with classrooms
        var existing = _context.Sessions.Include(s => s.classroom).FirstOrDefault(s => s.Id == session.Id);



        if (existing == null)
            return NotFound();

        // Update basic fields
        existing.SessionName = session.SessionName;
        existing.StartDate = session.StartDate;
        existing.EnDate = session.EnDate;
        existing.MainSessionId = session.MainSessionId; 
        existing.UpdatedOn = DateTime.Now;
        existing.UpdatedBy = 1;

        // Update related ClassRooms safely
        var allClasses = _context.classroom.Where(sc => !sc.IsDeleted).ToList();

        foreach (var cls in allClasses)
        {
            if (session.SelectedClassRoomIds != null && session.SelectedClassRoomIds.Contains(cls.Id))
            {
                cls.SessionId = existing.Id; // assign to current session
            }
            else if (cls.SessionId == existing.Id)
            {
                cls.SessionId = 0; // unassigned
            }
        }

        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }


    [HttpGet]
    public IActionResult Delete(int id)
    {
        var session = _context.Sessions.Include(s => s.classroom).FirstOrDefault(s => s.Id == id && !s.IsDeleted);

        if (session == null)
        {
            return NotFound();
        }
     
        return View(session);
    }


    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var session = _context.Sessions.FirstOrDefault(s => s.Id == id);

        if (session == null)
        {
            return NotFound();
        }
           
        // Soft delete
        session.IsDeleted = true;
        session.DeletedOn = DateTime.Now;
        session.DeletedBy = 1;

        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}