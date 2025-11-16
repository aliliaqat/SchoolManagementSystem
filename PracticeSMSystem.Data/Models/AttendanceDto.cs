using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models;


public class AttendanceDto
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime AttendanceDate { get; set; }

    [Required]
    public string AttendanceStatus { get; set; } = string.Empty;

    public string? AttendanceRemarks { get; set; }

   
    public bool? IsLate { get; set; }

 
    public bool? IsExcused { get; set; }

  
    public string? AttendanceType { get; set; } 

    public DateTime? MarkedAt { get; set; }

    public string? MarkedFromDevice { get; set; }

    public int? VerifiedByAdminId { get; set; }

   
    public bool? IsHoliDay { get; set; }

    
    public bool? IsManualEntry { get; set; }

   
    public int? StudentId { get; set; }

    
    public string? StudentFName { get; set; }

    
    public string? StudentLName { get; set; } 

    [NotMapped] //nullsafe 
    public string FullName => $"{StudentFName ?? ""} {StudentLName ?? ""}".Trim();



    public int? ClassRoomId { get; set; }

    
    public string? ClassRName { get; set; }

    
    public int? SectionId { get; set; }

   
    public string? SectionName { get; set; } = string.Empty;

    
    public int? SubjectId { get; set; }

   
    public string? SubjectName { get; set; } = string.Empty;

    
    public int? SessionId { get; set; }

    
    public string? SessionName { get; set; } = string.Empty;

   
    public int? MarkedByTeacherId { get; set; }

    
    public string? TFirstName { get; set; } = string.Empty;

    
    public string? TLastName { get; set; } = string.Empty;

}
