using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models
{
    public class TransportVehicle
    {
        public int Id { get; set; }
        public int TPVehicleCapacity { get; set; }

        public string TPVehicleNumber { get; set; } 
        public string TPDriverName { get; set; }
        public string TPDriverPhone { get; set; }

        public int RouteId { get; set; }
        public TransportRoute Route { get; set; }   
    }
}
