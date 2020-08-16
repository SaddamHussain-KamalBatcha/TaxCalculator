using Contract.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface ITaxRepository
    {
        float GetTaxRate(string municipality, string Date);

        void InsertTaxes(TaxDetailsDto taxDetails);
    }
}
