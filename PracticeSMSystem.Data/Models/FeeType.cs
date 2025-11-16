using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models
{
    public class FeeType
    {
        public int Id { get; set; }
        public string FeeTypeName { get; set; }

        public string FeeTypeDescription { get; set; }

            public ICollection<Fee> fees { get; set; }
    }
}
