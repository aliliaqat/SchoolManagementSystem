using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeSMSystem.Data.Models;



public class TeacherAttendanceDto
{
    [Key]
    public int Id { get; set; }

  
    public DateTime TeacherAttendanceDate { get; set; }


    public string? TeacherAttendanceStatus { get; set; }

    public string? TeacherAttendanceRemarks { get; set; }
    
    public int? TeacherId { get; set; }

 
    public string? TFirstName { get; set; }

    
    public string? TLastName { get; set; }

    [NotMapped]
    public string FullName => $"{TFirstName} {TLastName}";
    public int? DepartmentId { get; set; }

    
    public string? DName { get; set; }

    public int? ClassroomId { get; set; }

   
    public string ?ClassRName { get; set; }
}