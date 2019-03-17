using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Core.Models
{
    public class Record
    {
        public Customer Customer { get; set; }
        public LoanInfo LoanInfo { get; set; }
    }
}
