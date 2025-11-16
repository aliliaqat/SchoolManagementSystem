using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models;
[Table("Subject")]
public class Subject
{
    [Key]
    public int Id { get; set; }

    [Required]
    
    public string SubjectName { get; set; }

    [Required]
    
    public string SubjectCode { get; set; }

    // Foreign Keys
    public int? ClassRoomId { get; set; }
    public int? DepartmentId { get; set; }
    public int? TeacherId { get; set; }

    // Audit Trail
    public DateTime? CreatedOn { get; set; }
    public int? CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public DateTime? DeletedOn { get; set; }
    public int? DeleteBy { get; set; }

    [Required]
    public bool IsDeleted { get; set; }

    // Navigation Properties
    [ForeignKey("ClassRoomId")]
    [ValidateNever]
    public virtual ClassRoom ClassRoom { get; set; }

    [ForeignKey("DepartmentId")]
    [ValidateNever]
    public virtual Department Department { get; set; }

    [ForeignKey("TeacherId")]
    [ValidateNever]
    public virtual Teacher Teacher { get; set; }




}
