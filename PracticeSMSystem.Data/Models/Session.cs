using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace PracticeSMSystem.Data.Models;

[Table("Session")]
public class Session
{
    [Key]
    public int Id { get; set; }

    [Required]
    
    public string SessionName { get; set; } = string.Empty;

    [Required]
    
    public DateTime StartDate { get; set; }

    [Required]
    
    public DateTime EnDate { get; set; }

    // Audit Columns
    public int? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public int? DeletedBy { get; set; }
    public DateTime? DeletedOn { get; set; }
    public bool IsDeleted { get; set; } = false;

    // Navigation Property (EF relation ke liye)
    [ValidateNever] // Validation errors avoid karne ke liye
    public virtual List<ClassRoom> classroom { get; set; } = new List<ClassRoom>();

    // Helper property (View se selected classes aayengi)
    [NotMapped]
    public List<int> SelectedClassRoomIds { get; set; } = new List<int>();

    public int? MainSessionId { get; set; }   // Foreign Key (nullable(Not that ye just farzi ha dropdown ke lyea es ka database mean koi table nahi ha jo esy join kary)

    [ForeignKey("MainSessionId")]
    [ValidateNever]
    public Session? MainSession { get; set; } // Navigation property
}