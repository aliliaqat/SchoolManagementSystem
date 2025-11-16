using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models;

public class StaffAttendanceListDto
{
    public int Id { get; set; }
    public DateTime AttendanceDate { get; set; }
    public string? AttendanceStatus { get; set; }
    public string? AttendanceRemarks { get; set; }
    public int? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public int? DeletedBy { get; set; }
    public DateTime? DeletedOn { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public bool? IsExcused { get; set; }
    public DateTime? MarkedAt { get; set; }

    // 👨‍🏫 Staff Table Fields
    public int? StaffId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    // Computed Property for Full Name
    public string FullName => $"{FirstName} {LastName}".Trim();

    public DateTime? HireDate { get; set; }
    public string? Position { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }

    // 🏢 Department Table Fields
    public int? DepartmentId { get; set; }
    public string? DName { get; set; }
}
