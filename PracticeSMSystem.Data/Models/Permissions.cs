using Microsoft.Build.Framework;
using PracticeSMSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeSMSystem.Data.Enums;

namespace PracticeSMSystem.Data.Models;

[Table("Permissions")]
public class Permissions
{
    public int Id { get; set; }
    public int FeatureId { get; set; }
    public int RoleId { get; set; }
    public AccessLevel AccessLevel { get; set; }

    [NotMapped]
    public List<int>? SelectedLevels { get; set; }

    public Feature? Feature { get; set; }
    public Role? Role { get; set; }
}