using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;


namespace PracticeSMSystem.Data.Models;
[Table("Section")]
public class Section
{
    public int Id { get; set; }

    [Required]
    public string SectionName { get; set; }

    public bool IsDeleted { get; set; } = false;

}

