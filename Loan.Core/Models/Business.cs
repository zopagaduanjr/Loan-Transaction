
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Core.Models
{
    public class Business
    {
        public string Name { get; set; }
        public List<Customer> Customers { get; set; }
        public List<LoanInfo> LoanInfos { get; set; }
        public double LoanRate { get; set; }

    }
}
