using NuGet.DependencyResolver;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string RoleName { get; set; } = string.Empty;

        [Required, MaxLength(250)]
        public string RoleDescription { get; set; } = string.Empty;

        public DateTime? DateCreated { get; set; } = DateTime.Now;

        public int? CreatedBy { get; set; }

        public bool? Status { get; set; } = true;

        public List<UserAccount>? UserAccount { get; set; }
        public List<Permissions>? Permissions { get; set; }
    }

}
