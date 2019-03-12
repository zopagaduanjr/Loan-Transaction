using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Core.Models
{
    public class Jewelry
    {
        public Type Type { get; set; }
        public Quality Quality { get; set; }
        public double Weight { get; set; }
        public double Discount { get; set; }
        public string OtherDetail { get; set; }
        public double ActualValue { get; set; }

    }

    public enum Type
    {
        Ring,
        Necklace,
        Bracelet,
        Earring
    }

    public enum Quality
    {
        _10k,
        _18k,
        _21k

    }
}
