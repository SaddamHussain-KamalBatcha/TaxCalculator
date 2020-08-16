using System;
using System.Collections.Generic;
using System.Text;
using Contract.Models;

namespace Contract.Interface
{
    public interface ITaxProducerService
    {
        float GetTaxRate(string municipality, string Date);

        void InsertTaxes(TaxDetailsDto taxDetails);
    }
}
