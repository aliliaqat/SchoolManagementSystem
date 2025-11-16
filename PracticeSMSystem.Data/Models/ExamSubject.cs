using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models
{
    public class ExamSubject
    {
        public int Id { get; set; }
        public int MaxMarks { get; set; }

        public int PassingMarks { get; set; }

        public int ExamId { get; set; }
        public int SubjectId { get; set; }

        public Exam exam { get; set; }

        public Subject subject { get; set; }
    }
}
