using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeSMSystem.Data.Models;

namespace PracticeSMSystem.Data.Database;

public class SMSDbContext : DbContext
{
    public SMSDbContext(DbContextOptions<SMSDbContext> options) : base(options) { }



    public DbSet<Attendance> Attendance { get; set; }

    public DbSet<ClassRoom> classroom { get; set; }

    public DbSet<Teacher> teachers { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<Event> events { get; set; }
    public DbSet<Exam> exams { get; set; }
    public DbSet<ExamResult> examResults { get; set; }

    public DbSet<ExamSubject> examSubjects { get; set; }
    public DbSet<Fee> fees { get; set; }

    public DbSet<FeeType> feeTypes { get; set; }

    public DbSet<HostelAllocation> hostelAllocations { get; set; }

    public DbSet<HostelRoom> hostelRooms { get; set; }

    public DbSet<LibraryBook> libraryBooks { get; set; }

    public DbSet<LibraryCategorie> libraryCategories { get; set; }

    public DbSet<LibraryTransaction> libraryTransactions { get; set; }

    public DbSet<Payment> payments { get; set; }

    public DbSet<Role> Role { get; set; }
    public DbSet<Permission> Permissions { get; set; }

    public DbSet<Section> sections { get; set; }

    public DbSet<Session> Sessions { get; set; }
    public DbSet<Staff> Staff { get; set; }
    public DbSet<StaffAttendance> staffAttendances { get; set; }

    public DbSet<Subject> subjects { get; set; }

   

    public DbSet<TeacherClass> TeacherClasses { get; set; }
    public DbSet<TeacherAttendance> teacherAttendances { get; set; }

    public DbSet<Timetable> timetables { get; set; }

    public DbSet<TransportRoute> transportRoutes { get; set; }

    public DbSet<TransportVehicle> transportVehicles { get; set; }

    public DbSet<UserAccount> UserAccountABC { get; set; }

    public DbSet<Guardian> Guardians { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<GuardianStudent> GuardianStudents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GuardianStudent>()
        .HasKey(gs => new { gs.GuardianId, gs.StudentId });

        modelBuilder.Entity<GuardianStudent>()
            .HasOne(gs => gs.Guardian)
            .WithMany(g => g.GuardianStudents)
            .HasForeignKey(gs => gs.GuardianId);

        modelBuilder.Entity<GuardianStudent>()
            .HasOne(gs => gs.Student)
            .WithMany(s => s.GuardianStudents)
            .HasForeignKey(gs => gs.StudentId);


        // Table mapping
        modelBuilder.Entity<Role>().ToTable("Role");

        // Teacher → Department (many teachers in one department)
        modelBuilder.Entity<Teacher>()
            .HasOne(t => t.Department)
            .WithMany(d => d.Teachers)
            .HasForeignKey(t => t.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        // Staff → Department (many staff members in one department)
        modelBuilder.Entity<Staff>()
            .HasOne(s => s.Department)
            .WithMany(d => d.StaffMembers)
            .HasForeignKey(s => s.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        // Department → Head (one head per department)
        modelBuilder.Entity<Department>()
            .HasOne(d => d.Head)
            .WithMany() // Head does not need a collection
            .HasForeignKey(d => d.DepHeadId)
            .OnDelete(DeleteBehavior.Restrict);




       
        base.OnModelCreating(modelBuilder);
    }
}
