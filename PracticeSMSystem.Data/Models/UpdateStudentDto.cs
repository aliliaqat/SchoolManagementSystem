using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models;

public class UpdateStudentDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string StudentFName { get; set; }

    [Required]
    public string StudentLName { get; set; }

    [Required]
    public string Gender { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    public string? Address { get; set; }
    public string? PhoneNo { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    public int ClassRoomId { get; set; }

    public string? SpecialInstruction { get; set; }
}
