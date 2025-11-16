using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models;

[Table("Timetable")]
public class Timetable
{
    [Key]
    public int Id { get; set; }

    [Required]
    public TimeSpan StartTime { get; set; }

    [Required]
    public TimeSpan EndTime { get; set; }

    [Required]
    [StringLength(50)]
    public string DayOfWeek { get; set; }

    public int? ClassId { get; set; } // Optional if not assigned yet
    public int? SectionId { get; set; }
    public int? SubjectId { get; set; }

    public int? TeacherId { get; set; } // Optional if not assigned yet
    public virtual Teacher Teacher { get; set; }

}
