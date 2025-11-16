using Microsoft.AspNetCore.Mvc;
using PracticeSMSystem.Data.Database;
using PracticeSMSystem.Data.Models;
using System;
using System.Linq;

namespace PracticeSMSystem.Controllers
{
    public class StaffController : Controller
    {
        private readonly SMSDbContext _context;

        public StaffController(SMSDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var staffList = _context.Staff.Where(s => !s.IsDeleted).ToList();

            ViewBag.RoleList = _context.Role.ToDictionary(a => a.Id, b => b.RoleName);

            return View("StaffList", staffList);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var staff = _context.Staff.FirstOrDefault(s => s.Id == id && !s.IsDeleted);
            if (staff == null)
            {
                return NotFound();
            }
           
            return View(nameof(staff));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Staff staff)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(staff));
            }
               
            SetAuditFields(staff, isNew: true);
            _context.Staff.Add(staff);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var staff = _context.Staff.FirstOrDefault(s => s.Id == id && !s.IsDeleted);
            ViewBag.Rolelist = _context.Role.ToList();
            return View(staff);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Staff staff)
        {
            if (!ModelState.IsValid)
            {
                return View(staff);
            }
               
            var existingStaff = _context.Staff.FirstOrDefault(s => s.Id == staff.Id) ?? new Staff();
            CopyStaffFields(staff, existingStaff);
            SetAuditFields(existingStaff, isNew: staff.Id == 0);

            if (staff.Id == 0)
                _context.Staff.Add(existingStaff);

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var staff = _context.Staff.FirstOrDefault(s => s.Id == id && !s.IsDeleted);
            if (staff == null)
            {
                return NotFound();
            }
               
            return View(nameof(staff));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var staff = _context.Staff.FirstOrDefault(s => s.Id == id);
            if (staff == null)
            {
                return NotFound();
            }

            staff.IsDeleted = true;
            staff.DeletedOn = DateTime.Now;
            staff.DeletedBy = 1;

            _context.Staff.Update(staff);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }



        // 🔄 Helper Methods
        private void SetAuditFields(Staff staff, bool isNew)
        {
            staff.DeletedOn = DateTime.Now;
            staff.DeletedBy = 1;

            if (isNew)
            {
                staff.CreatedOn = DateTime.Now;
                staff.CreatedBy = 1;
                staff.IsDeleted = false;
            }
        }

        // 🔄 Helper Methods
        private void CopyStaffFields(Staff source, Staff target)
        {
            target.FirstName = source.FirstName;
            target.LastName = source.LastName;
            target.Gender = source.Gender;
            target.Dob = source.Dob;
            target.HireDate = source.HireDate;
            target.Position = source.Position;
            target.RoleId = source.RoleId;
            target.Email = source.Email;
            target.Phone = source.Phone;
        }
    }
}