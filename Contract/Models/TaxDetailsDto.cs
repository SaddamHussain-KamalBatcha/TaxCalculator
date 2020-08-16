using System;
using System.Collections.Generic;
using System.Text;

namespace Contract.Models
{
    public class TaxDetailsDto
    {
        public string Municipality { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public float TaxRate { get; set; }

        public string TaxSlab { get; set; }
    }
}
