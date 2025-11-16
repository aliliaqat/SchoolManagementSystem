using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models
{
    public class HostelRoom
    {
        public int Id { get; set; }

        public int Capacity { get; set; }

        public string HRoomNumber { get; set; }

        public string HostelName { get; set; }

        public ICollection<HostelRoom> hostelRooms { get; set; }
    }
}
