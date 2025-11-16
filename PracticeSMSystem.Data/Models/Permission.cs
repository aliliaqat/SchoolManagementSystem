using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeSMSystem.Data.Models;


namespace PracticeSMSystem.Data.Models;

[Table("Permission")]
public class Permission
{
    public int Id { get; set; }

    [Column("FeatureId")]
    public int FeatureId { get; set; }

    [Column("RoleId")]
    public int RoleId { get; set; }

    [Column("AccessLevel")]
    public int AccessLevel { get; set; }

    public Feature Feature { get; set; }
    public Role Role { get; set; }
}
