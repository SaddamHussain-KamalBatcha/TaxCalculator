using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contract.Interface;
using Contract.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TaxCalculator.Controllers
{
    [ApiController]
    [Route("api/taxes")]
    public class TaxCalculatorController : ControllerBase
    {
        private readonly ITaxProducerService _taxProducerService;
        public TaxCalculatorController(ITaxProducerService taxProducerService)
        {
            _taxProducerService = taxProducerService;
        }

        /// <summary>
        /// Gets a tax rate for given date.
        /// </summary>
        /// <param name="municipalityName">municipality.</param>
        /// <param name="date">date.</param>
        /// <returns>Returns tax rate.</returns>
        [Route("municipality/{municipalityName}/date/{date}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<float> GetTaxRate(string municipalityName, string date)
        {
            var result = _taxProducerService.GetTaxRate(municipalityName, date);
            return Ok(result);
        }

        /// <summary>
        /// Post tax details.
        /// </summary>
        /// <returns>Returns Ok.</returns>
        [Route("post")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Post([FromBody]TaxDetailsDto taxDetails)
        {
            _taxProducerService.InsertTaxes(taxDetails);
            return Ok();
        }
    }
}
