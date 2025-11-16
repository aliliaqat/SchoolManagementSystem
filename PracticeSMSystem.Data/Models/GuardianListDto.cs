using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models;

public class GuardianListDto
{
    [Key]
    public int GuardianId { get; set; }

    [Required]
    public string GFirstName { get; set; } = string.Empty;

    [Required]
    public string GLastName { get; set; } = string.Empty;

    [NotMapped]
    public string FullName => $"{GFirstName} {GLastName}";
    [NotMapped]
    public string GRelationship { get; set; } = string.Empty;

    public string GPhone { get; set; } = string.Empty;

    public string GEmail { get; set; } = string.Empty;

    public string GAddress { get; set; } = string.Empty;

    public int StudentCount { get; set; }

    [NotMapped]
    public ICollection<GuardianStudent> GuardianStudents { get; set; }
    [NotMapped]
    public List<int>? SelectedStudentIds { get; set; }

}

