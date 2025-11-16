using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeSMSystem.Data.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        
        public int Id { get; set; }

        [Required]
        public string StudentFName { get; set; }

        [Required]
        public string StudentLName { get; set; }

        [NotMapped]
        public string FullName => $"{StudentFName} {StudentLName}";
        

        [Required]
        public string Gender { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public DateTime AddmissionDate { get; set; }

        public bool? IsDeleted { get; set; } = false;

        public string? Address { get; set; }

        public string? PhoneNo { get; set; }

        public string? Email { get; set; }

        public string? Status { get; set; }

        // ✅ Foreign Key Setup
        [Required]
        [ForeignKey("ClassRoom")]
        public int ClassRoomId { get; set; }

        [InverseProperty("Students")]
        [ValidateNever]
        public virtual ClassRoom ClassRoom { get; set; }

        [NotMapped]
        public int SectionId { get; set; }

        [NotMapped]
        [ValidateNever]
        public Section Section { get; set; }


       
        public string? Activity { get; set; }


        [Column("SpecialInstruction")]
        public string? SpecialInstruction { get; set; }

        public virtual List<GuardianStudent> GuardianStudents { get; set; } = new List<GuardianStudent>();
    }
}