using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Contract.Models;
using Repository.Context;
using Repository.Entities;

namespace Repository
{
    public class TaxRepository : ITaxRepository
    {
        readonly TaxDbContext _dbContext;

        public TaxRepository(TaxDbContext context)
        {
            _dbContext = context;
        }

        public float GetTaxRate(string municipality, string date)
        {
            var result = _dbContext.Taxes.Where(x => x.Municipality == municipality).ToList();

            foreach (var x in result)
            {
                if (x.TaxSlab == "daily")
                {
                    if (x.FromDate == date)
                        return x.TaxRate;
                }
                if (x.TaxSlab == "weekly")
                {
                    return CalculateTaxRate(date, x);
                }
                if (x.TaxSlab == "monthly")
                {
                    return CalculateTaxRate(date, x);

                }
                if (x.TaxSlab == "yearly")
                {
                    return CalculateTaxRate(date, x);
                }
            }
            return 0;
        }

        private static float CalculateTaxRate(string date, TaxInfo x)
        {
            DateTime.TryParse(date, out DateTime inputDate);
            DateTime.TryParse(x.FromDate, out DateTime fromdate);
            DateTime.TryParse(x.ToDate, out DateTime toDate);
            if (inputDate >= fromdate && inputDate <= toDate)
            {
                return x.TaxRate;
            }

            return 0;
        }
       
        public void InsertTaxes(TaxDetailsDto taxDetails)
        {
            var taxes = new TaxInfo()
            {
                Municipality = taxDetails.Municipality,
                FromDate = taxDetails.FromDate,
                TaxRate = taxDetails.TaxRate,
                TaxSlab = taxDetails.TaxSlab,
                ToDate = taxDetails.ToDate
            };

            _dbContext.Add(taxes);
            _dbContext.SaveChanges();
        }
    }
}
