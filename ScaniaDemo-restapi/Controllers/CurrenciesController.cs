using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScaniaDemo_restapi.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScaniaDemo_restapi.Controllers
{
    [Route("api/[controller]")]
    public class CurrenciesController : Controller
    {
        private readonly ICurrencyConverter _currencyConverter;

        public CurrenciesController(ICurrencyConverter currencyConverter) {
            _currencyConverter = currencyConverter;
        }

        // GET: api/values
        [HttpGet]
        public async Task<string> Get()
        {
            return await _currencyConverter.GetCurrencies();
        }

        [HttpGet]
        [Route("{paramBase}")]
        public async Task<string> GetByBase(string paramBase)
        {
            return await _currencyConverter.GetCurrencies(paramBase);
        }
    }
}
