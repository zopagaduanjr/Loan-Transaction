using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Core.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public double Money { get; set; }
        public List<Jewelry> Jewelries { get; set; }

        public List<LoanInfo> Loans { get; set; }

        public Customer()
        {
            Jewelries = new List<Jewelry>();
            Loans = new List<LoanInfo>();
        }
    }
}
