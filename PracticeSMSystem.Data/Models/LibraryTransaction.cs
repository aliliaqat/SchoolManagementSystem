using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models
{
    public class LibraryTransaction
    {
        public int Id { get; set; }
        public DateOnly IssueDate { get; set; }

        public DateOnly ReturnDate { get; set; }

        public string Status { get; set; }

        public int BookId { get; set; }
        public LibraryBook book { get; set; }

        public int StudentId { get; set; }
        public Student student { get; set; }    
    }
}
