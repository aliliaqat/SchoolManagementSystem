using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models;


[Table("GuardianStudent")]
public class GuardianStudent
{
    [Key]
   
    public int GuardianId { get; set; }

    [Key]
   
    public int StudentId { get; set; }

    
   
    public string? Relationship { get; set; }

    // Navigation properties
    public virtual Guardian Guardian { get; set; }
    public virtual Student Student { get; set; }
}


