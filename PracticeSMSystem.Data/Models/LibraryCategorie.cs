using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models
{
    public class LibraryCategorie
    {
        public int Id { get; set; }

        public string LibCategorieName { get; set; }
        public ICollection<LibraryBook> libraryBooks { get; set; }
    }
}
