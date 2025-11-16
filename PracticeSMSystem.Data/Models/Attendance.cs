using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models;

[Table("Attendance")]
public class Attendance
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime AttendanceDate { get; set; }

    [Required]
    public string AttendanceStatus { get; set; } = string.Empty;
    public bool IsDeleted { get; set; } = false;
    public string? AttendanceRemarks { get; set; }

    public int? StudentId { get; set; }

    public int? ClassRoomId { get; set; }

    public int? SectionId { get; set; }

    public int? SubjectId { get; set; }

    public int? MarkedByTeacherId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

   
    public bool? IsLate { get; set; }

    public bool? IsExcused { get; set; }

    
    public string? AttendanceType { get; set; }

    public DateTime? MarkedAt { get; set; }

    public DateTime? MarkedFromDevice { get; set; }

    public int? VerifiedByAdminId { get; set; }

    
    public bool? IsHoliDay { get; set; }

    
    public bool? IsManualEntry { get; set; }

    public int? AttendanceSessionId { get; set; }

    public int? SessionId { get; set; }

    // ✅ Navigation Properties
    [ValidateNever]
    public virtual Student Student { get; set; }
    [ValidateNever]
    public virtual ClassRoom ClassRoom { get; set; }
    [ValidateNever]
    public virtual Section Section { get; set; }
    [ValidateNever]
    public virtual Subject Subject { get; set; }
}

