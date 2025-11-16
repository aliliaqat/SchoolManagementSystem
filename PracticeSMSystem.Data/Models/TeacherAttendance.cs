using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.CodeAnalysis;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models;
[Table("TeacherAttendance")]
public class TeacherAttendance
{
    [Key]
    public int Id { get; set; }

    public int? TeacherId { get; set; }


    public string? TFirstName { get; set; }
    public string? TLastName { get; set; }

    [NotMapped]
    public string FullName => $"{TFirstName} {TLastName}";



    public DateTime? TeacherAttendanceDate { get; set; }

    
    public string? TeacherAttendanceStatus { get; set; } // e.g. Present, Absent
    

    public string? TeacherAttendanceRemarks { get; set; } // Optional

    [Required]
    public bool IsDeleted { get; set; }

    public DateTime? UpDatedAt { get; set; }
    public int? DepartmentId { get; set; }

    public int? ClassRoomId { get; set; }


    // Optional navigation properties
    [ValidateNever]
    public virtual Teacher? Teacher { get; set; }
    [ValidateNever]
    public virtual Department? Department { get; set; }
    [ValidateNever]
    public virtual ClassRoom? ClassRoom { get; set; }

}
