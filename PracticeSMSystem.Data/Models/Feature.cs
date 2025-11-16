using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models;

[Table("Feature")]
public class Feature
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Permission> Permissions { get; set; } = new List<Permission>();
}