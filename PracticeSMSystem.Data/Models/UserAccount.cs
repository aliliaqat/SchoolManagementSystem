using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models
{
    [Table("UserAccount")]
    public class UserAccount
    {
        public int Id { get; set; }
        public required string UAccountUsername { get; set; }

        public required string PasswordHash { get; set; }
        public required string PersonType { get; set; }

        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role role { get; set; }

    }
}
