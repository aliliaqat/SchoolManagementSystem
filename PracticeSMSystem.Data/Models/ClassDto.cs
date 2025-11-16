using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models;

public class ClassDto
{
    public int Id { get; set; }

    public string ClassRName { get; set; } = string.Empty;

    public string DepartmentName { get; set; } = string.Empty;

    public string SessionName { get; set; } = string.Empty;

    public string? SectionName { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int /*TotalStudents*/ StudentCount { get; set; }
}
