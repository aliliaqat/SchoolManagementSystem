using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models;

[Table("StaffAttendance")]
public class StaffAttendance
{
    [Key]
    public int Id { get; set; }

    // Foreign Key for Staff
    public int? StaffId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";

    [Required]
    public DateTime AttendanceDate { get; set; }

    [MaxLength(10)]
    public string? AttendanceStatus { get; set; } // e.g. Present, Absent, Leave, Late

    [MaxLength(200)]
    public string? AttendanceRemarks { get; set; }

    [Required]
    public bool IsDeleted { get; set; } = false;

    public int? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }

    public int? DeletedBy { get; set; }
    public DateTime? DeletedOn { get; set; }

    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }

    public bool? IsLate { get; set; }
    public bool? IsExcused { get; set; }

    public DateTime? MarkedAt { get; set; }

    public int? DepartmentId { get; set; }

    // 🔗 Navigation Properties
    [ValidateNever]
    public virtual Staff? Staff { get; set; }

    [ValidateNever]
    public virtual Department? Department { get; set; }
}