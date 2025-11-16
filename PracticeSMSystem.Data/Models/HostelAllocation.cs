using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models
{
    public class HostelAllocation
    {
        public int Id { get; set; }
        public DateOnly HAAllocationDate { get; set; }
        public DateOnly HAReleaseDate { get; set; }

        public int RoomId { get; set; }
        public HostelRoom hostelRoom { get; set; }

        public int StudentId { get; set; }
        public Student student { get; set; }    
    }
}
