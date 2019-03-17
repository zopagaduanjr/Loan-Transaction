
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
        public List<Record> Records { get; set; }
    }
}
