using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models;

public class StudentList
{
    [Column("StudentId")]
    public int StudentId { get; set; }

    [Column("StudentFName")]
    public string? StudentFName { get; set; }

    [Column("StudentLName")]
    public string? StudentLName { get; set; }

    [NotMapped]
    public string FullName => $"{StudentFName ?? ""} {StudentLName ?? ""}";

    [Column("Gender")]
    public string? Gender { get; set; }

    [Column("DateOfBirth")]
    public DateTime? DateOfBirth { get; set; }   // ✅ Nullable

    [Column("AddmissionDate")]
    public DateTime? AdmissionDate { get; set; } // ✅ Nullable

    [Column("Email")]
    public string? Email { get; set; }

    [Column("SpecialInstruction")]
    public string? SpecialInstruction { get; set; }

    [Column("GuardianId")]
    public int? GuardianId { get; set; }         // ✅ Nullable

    [Column("GFirstName")]
    public string? GFirstName { get; set; }

    [Column("GLastName")]
    public string? GLastName { get; set; }

    [Column("GRelationship")]
    public string? GRelationship { get; set; }



}


//public class StudentDto
//{
//    public int StudetnId { get; set; }

//    public string StudentFName { get; set; } = string.Empty;
//    public string StudentLName { get; set; } = string.Empty;
//    [NotMapped]
//    public string FullName => $"{StudentFName} {StudentLName}";
//    public string Gender { get; set; } = string.Empty;
//    public DateTime DateOfBirth { get; set; }
//    public DateTime AddmissionDate { get; set; }

//    public string? Address { get; set; }
//    public string? PhoneNo { get; set; }
//    public string? Email { get; set; }
//    public string? Status { get; set; }
//    public string? SpecialInstruction { get; set; }

//    public string ClassRName { get; set; } = string.Empty;
//    public DateTime? StartDate { get; set; }
//    public DateTime? EndDate { get; set; }

//    public string SessionName { get; set; } = string.Empty;
//    public string? SectionName { get; set; }   // ✅ Nullable (LEFT JOIN سے آتا ہے)

//    public int? GuardianId { get; set; }       // ✅ Nullable (Guardian لازمی نہیں ہے)
//    public string? GFirstName { get; set; }
//    public string? GLastName { get; set; }
//    public string? GRelationship { get; set; }
//    public string? GPhone { get; set; }
//    public string? GEmail { get; set; }
//    public string? GAddress { get; set; }

//}
