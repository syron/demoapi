using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
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

        // GET: api/trucks
        [HttpGet]
        public async Task<List<TruckEntity>> Get()
        {
            return await _trucks.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<TruckEntity> Get(int id)
        {
            return await _trucks.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]TruckEntity value)
        {
            value.PartitionKey = value.ModelId.ToString();
            value.RowKey = value.Id.ToString();
            await _trucks.Add(value);
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
