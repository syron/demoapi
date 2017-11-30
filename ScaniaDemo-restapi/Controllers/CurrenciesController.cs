using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScaniaDemo_restapi.Controllers
{
    [Route("api/[controller]")]
    public class CurrenciesController : Controller
    {
        // GET: api/values
        [HttpGet]
        public string Get()
        {
            var url = "https://api.fixer.io/latest";
            var client = new HttpClient();
            var stringTask = client.GetStringAsync(url);
            stringTask.Wait();

            return stringTask.Result;
        }
    }
}
