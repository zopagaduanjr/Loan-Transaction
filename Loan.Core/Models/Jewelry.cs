using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Core.Models
{

    public class Jewelry
    {
        private string _qualityString;
        public int Id { get; set; }

        public Type Type { get; set; }
        public Quality Quality { get; set; }

        public string QualityString
        {
            get
            {
                var quail = Quality.ToString();
                return quail;
            }
            set => _qualityString = value;
        }

        public double Weight { get; set; }
        public double Discount { get; set; }
        public string OtherDetail { get; set; }
        public double ActualValue { get; set; }

        public int UniqueId { get; set; }

        public int CustomerId { get; set; }

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
        _10k_,
        _18k_,
        _21k_

    }
}
