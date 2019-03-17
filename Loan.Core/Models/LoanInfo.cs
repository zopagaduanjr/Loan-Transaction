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

        public float Amount { get; set; }
        public DateTime DateTime { get; set; }
        public Jewelry Jewelry { get; set; }
        public Double AmountLoan { get; set; }
        public Customer Customer { get; set; }


    }
}
