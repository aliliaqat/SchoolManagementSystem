using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models;
[Table("Exam")]
public class Exam
{
    public int Id { get; set; }
    public string EName { get; set; }
    public DateOnly EStartDate { get; set; }

    public DateOnly EEndDate { get; set; }

    public int ClassId { get; set; }
    public ClassRoom @class { get; set; }
    public int SectionId { get; set; }
    public Section section { get; set; }

    public ICollection<ExamResult> examResults { get; set; }
    public ICollection<ExamSubject> examSubjects { get; set; }

    


}
