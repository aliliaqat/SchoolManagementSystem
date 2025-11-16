using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models
{
    public class Event
    {
        public int Id { get; set; } 
        public string EName { get; set; }

        public string EDescription { get; set; }

        public DateOnly EStartDate { get; set; }

        public DateOnly EEndDate { get; set; }

        public string ELocation { get; set; }
    }
}
