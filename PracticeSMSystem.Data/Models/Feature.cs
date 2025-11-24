using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models;

[Table("Feature")]
public class Feature
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string DisplayName { get; set; }

    // Navigation property
    public List<Permissions> Permissions { get; set; } = new List<Permissions>();
}

