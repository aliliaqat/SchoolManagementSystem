using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace PracticeSMSystem.Data.Models;

[Table("ClassRoom")]
public class ClassRoom
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string ClassRName { get; set; } = string.Empty;

    [Required]
    public int DepartmentId { get; set; }
    [Required]
    public int SessionId { get; set; }
    public string? Description { get; set; }

    // 📅 New Fields for Enrolment Screen
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? SectionId { get; set; }

    [ForeignKey("SectionId")]
    [ValidateNever]
    public virtual Section Section { get; set; }


    // Audit Columns
    public int? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public int? DeletedBy { get; set; }
    public DateTime? DeletedOn { get; set; }

    // Non-nullable bool
    public bool IsDeleted { get; set; } = false;


    // 🔗 Navigation Properties for Dropdowns

    [ForeignKey("SessionId")]
    [ValidateNever]

    public virtual Session Session { get; set; }

    [ForeignKey("DepartmentId")]
    [ValidateNever]

    public virtual Department Department { get; set; }

    // 🔗 Optional: Navigation for Students
    [ValidateNever]
    public virtual List<Student> Students { get; set; }

    public virtual List<TeacherClass> TeacherClasses { get; set; } = new List<TeacherClass>();

}