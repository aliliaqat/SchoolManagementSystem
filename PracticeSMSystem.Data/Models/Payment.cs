using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal PaymentAmount { get; set; }

        public DateOnly PaymentDate { get; set; }

        public string PaymentMethod { get; set; }

        public string PaymentReferenceNo { get; set; }

        public int StudentId { get; set; }
        public Student student { get; set; }
    }
}
