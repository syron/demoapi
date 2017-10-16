using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScaniaDemo_restapi.Models;
using ScaniaDemo_restapi.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScaniaDemo_restapi.Controllers
{
    [Route("api/[controller]")]
    public class TrucksController : Controller
    {
        ITrucks _trucks;
        public TrucksController(ITrucks trucks) {
            _trucks = trucks;
        }

        internal List<Truck> getTrucks() {
            List<Truck> trucks = new List<Truck>();

            trucks.Add(new Truck() { Id = 1, ModelId = 230, Driver = "Robert Mayer", Km = 1337, RegistrationNumber = "ABC 123" });
            trucks.Add(new Truck() { Id = 2, ModelId = 230, Driver = "Winston Mayer", Km = 242323, RegistrationNumber = "DEF 456" });

            return trucks;
        }

        // GET: api/trucks
        [HttpGet]
        public IEnumerable<Truck> Get()
        {
            return this.getTrucks();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Truck Get(int id)
        {
            return this.getTrucks().FirstOrDefault(t => t.Id == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
