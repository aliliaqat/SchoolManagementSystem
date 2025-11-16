using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models
{
    public class ExamResult
    {
        public int Id { get; set; }

        public int MarksObtained { get; set; }
        public string Grade { get; set; }

        public int ExamId { get; set; }
        public Exam exam { get; set; }
        public int StudentId { get; set; }
        public Student student { get; set; }

        public int SubjectId { get; set; }
        public Subject subject { get; set; }
        
        
        
    }
}
