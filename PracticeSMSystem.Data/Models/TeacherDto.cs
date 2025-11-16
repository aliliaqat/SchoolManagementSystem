using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models;
[Table("Teacher")]
public class TeacherDto
{
    // Teacher Info
    public int TeacherId { get; set; }
    public string TFirstName { get; set; }
    public string TLastName { get; set; }
    [NotMapped]
    public string FullName => $"{TFirstName} {TLastName}";

    public string Gender { get; set; }
    public DateTime HireDate { get; set; }
    public string? Qualification { get; set; }
    public string? Email { get; set; }
    public string? TeacherStatus { get; set; }

    // Department Info (nullable because of LEFT JOIN)
    public int? DepartmentId { get; set; }
    public string? DepartmentName { get; set; }
    public string? DDescription { get; set; }
    public int? DepHeadId { get; set; }

    public string AssignedClasses { get; set; }

}
