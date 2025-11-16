using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models
{
    public class TransportRoute
    {
        public int Id { get; set; }
        public string TRName { get; set; }

        public string TRDescription { get; set; }

        public ICollection<TransportVehicle> transportVehicles { get; set; }
    }
}
