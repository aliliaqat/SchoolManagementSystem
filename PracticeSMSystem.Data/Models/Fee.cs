using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Models
{
    public class Fee
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }

        public DateOnly DueDate { get; set; }

        public string Status { get; set; }

        public int StudentId { get; set; }
        public Student student { get; set; }    


        public int FeeTypeId { get; set; }
        public FeeType feeType { get; set; }



    }
}
