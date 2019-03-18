using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Core.Models
{

    public class LoanInfo
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public double CheckOutAmount { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime CheckOutDateTime { get; set; }
        public Jewelry Jewelry { get; set; }
        public Customer Customer { get; set; }
    }
}
