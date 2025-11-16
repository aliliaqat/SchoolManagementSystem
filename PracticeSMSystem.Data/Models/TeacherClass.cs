using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models;

[Table("TeacherClass")]
public class TeacherClass
{
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey("Teacher")]
    public int TeacherId { get; set; }

    [Required]
    [ForeignKey("ClassRoom")]
    public int ClassRoomId { get; set; }

    // Navigation properties
    public virtual Teacher Teacher { get; set; }
    public virtual ClassRoom ClassRoom { get; set; }
}