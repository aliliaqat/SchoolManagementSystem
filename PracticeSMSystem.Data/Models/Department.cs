using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models;


[Table("Department")]
public class Department
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string DName { get; set; } = string.Empty;

    [Required]
    public string DDescription { get; set; } = string.Empty;

    public int? DepHeadId { get; set; }

    // Audit Columns
    public int? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public int? DeletedBy { get; set; }
    public DateTime? DeletedOn { get; set; }

    // Non-nullable bool
    public bool IsDeleted { get; set; } = false;

    // Navigation
    [ForeignKey(nameof(DepHeadId))]
    public virtual Staff? Head { get; set; }

    public virtual List<Staff> StaffMembers { get; set; } = new();
    public virtual List<Teacher> Teachers { get; set; } = new();
    public virtual List<ClassRoom> classroom { get; set; } = new();
}