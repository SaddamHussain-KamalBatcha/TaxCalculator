using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
{
    public class TaxInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Municipality { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public float TaxRate { get; set; }

        public string TaxSlab { get; set; }
    }
}
