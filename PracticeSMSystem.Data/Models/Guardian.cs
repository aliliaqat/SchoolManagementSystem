using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace PracticeSMSystem.Data.Models;

[Table("Guardian")]
public class Guardian
{
    [Key]
    public int Id { get; set; }

    [Required]
    
    public string GFirstName { get; set; }

    [Required]
   
    public string GLastName { get; set; }

    [NotMapped]
    public string FullName => $"{GFirstName} {GLastName}";

    

    public string? GRelationship { get; set; }

    [Required]
   
    public string GPhone { get; set; }

   
   
    public bool? IsDeleted { get; set; }
    [Required]
    public string GEmail { get; set; }
    [NotMapped]
    public int StudentCount => GuardianStudents?.Count ?? 0;

    [NotMapped]
    public List<string> StudentNames => GuardianStudents?.Select(gs => gs.Student.StudentFName + " " + gs.Student.StudentLName).ToList() ?? new List<string>();


    [NotMapped]
    public List<int> SelectedStudentIds { get; set; } = new();

    [Required]
   
    public string GAddress { get; set; }

    // Navigation property
    public virtual List<GuardianStudent> GuardianStudents { get; set; } = new List<GuardianStudent>();
}
