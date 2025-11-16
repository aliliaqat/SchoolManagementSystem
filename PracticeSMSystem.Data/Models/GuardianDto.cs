using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models;

public class GuardianDto
{
    public int Id { get; set; }
    public string GFirstName { get; set; } = string.Empty;
    public string GLastName { get; set; } = string.Empty;
    public string GRelationship { get; set; } = string.Empty;
    public string GPhone { get; set; } = string.Empty;
    public string GEmail { get; set; } = string.Empty;
    public string GAddress { get; set; } = string.Empty;

}
