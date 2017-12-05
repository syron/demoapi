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
    public class RestaurantsController : Controller
    {
        private readonly IRestaurants _restaurants;

        public RestaurantsController(IRestaurants restaurants) {
            _restaurants = restaurants;
        }

        [HttpGet]
        public IEnumerable<Restaurant> Get()
        {
            return _restaurants.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public Restaurant GetById(int id) {
            return _restaurants.GetById(id);
        }
    }
}
