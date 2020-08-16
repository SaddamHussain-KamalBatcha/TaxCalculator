using Contract.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Contract.Models;
using Repository;

namespace Domain.Services
{
    public class TaxProducerService : ITaxProducerService
    {
        private readonly ITaxRepository _taxRepository;

        public TaxProducerService(ITaxRepository taxRepository)
        {
            _taxRepository = taxRepository;
        }

        public float GetTaxRate(string municipality, string Date)
        {
            var result = _taxRepository.GetTaxRate(municipality, Date);

            if (result == 0)
            {
                throw new InvalidDataException("No tax found for given date");
            }

            return result;
        }

        public void InsertTaxes(TaxDetailsDto taxDetails)
        {
           _taxRepository.InsertTaxes(taxDetails);
        }
    }
}
