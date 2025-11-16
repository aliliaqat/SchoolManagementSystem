using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models;
[Table("Teacher")]
public class Teacher
{
    [Key]
    public int Id { get; set; }

    [Required]
    
    public string TFirstName { get; set; }

    [Required]
    
    public string TLastName { get; set; }

    public string FullName => $"{TFirstName} {TLastName}";
    [Required]
    public DateTime HireDate { get; set; }
   
    public decimal? Salary { get; set; }

    public string? Qualification { get; set; }
    
    public DateTime DateOfBirth { get; set; }
    
    public string? Activity {  get; set; }
   
    public string? Email { get; set; }
   
    public string? Address { get; set; }
    
    public string? PhoneNo { get; set; }

    
    
    public string? Status { get; set; }
    [Required]
    public string Gender { get; set; }
    public int DepartmentId { get; set; }

    public int? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }

    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }

    public DateTime? DeletedOn { get; set; }
    public int? DeletedBy { get; set; }

    [Required]
    public bool IsDeleted { get; set; }

    [ForeignKey("DepartmentId")]
    [ValidateNever]
    public virtual Department Department { get; set; }

    [NotMapped] 
    public int ClassRoomId { get; set; }
    [NotMapped]
    public List<int> SelectedClassIds { get; set; } = new List<int>();
    public virtual List<TeacherClass> TeacherClasses { get; set; } = new List<TeacherClass>();

}

