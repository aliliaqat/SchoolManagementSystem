using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models;


[Table("Staff")]
public class Staff
{
    [Key]
    public int Id { get; set; }

    public int? DepartmentId { get; set; }

    [Required]
   
    public string FirstName { get; set; } = string.Empty;

    [Required]
    
    public string LastName { get; set; } = string.Empty;
    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";

    [Required]
    public int Gender { get; set; }

    public DateTime? Dob { get; set; }

    [Required]
    public DateTime HireDate { get; set; }

    [Required, MaxLength(100)]
    public string Position { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string Phone { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    [Required]
    public int RoleId { get; set; }

    // Audit Columns
    public int? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public int? DeletedBy { get; set; }
    public DateTime? DeletedOn { get; set; }
    
    // Non-nullable bool
    public bool IsDeleted { get; set; } = false;
    [ForeignKey(nameof(DepartmentId))]
    public virtual Department? Department { get; set; }
    //// 🔗 Navigation to Department (staff belongs to a department)
    //[ForeignKey("DepartmentId")]
    //public virtual Department? Department { get; set; }

    // 🔄 Reverse Navigation for HeadOfDepartment (so old code still works)
    //[InverseProperty("Head")]
    //public virtual Department? HeadOfDepartment { get; set; }
}