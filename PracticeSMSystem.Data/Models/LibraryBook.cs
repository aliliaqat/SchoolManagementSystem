using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models
{
    public class LibraryBook
    {
      public int Id { get; set; }   
        public int Quantity { get; set; }

        public string LBookTitle { get; set; }  

        public string LBookAuthor { get; set; }

        public string LBookISBN { get; set; }

        public int CategoryId { get; set; } 
        public LibraryCategorie libraryCategorie { get; set; }

        public ICollection<LibraryTransaction> libraryTransactions { get; set; }

    }
}
