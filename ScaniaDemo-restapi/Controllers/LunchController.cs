using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.RegularExpressions;
using ScaniaDemo_restapi.Models;
using ScaniaDemo_restapi.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScaniaDemo_restapi.Controllers
{
    [Route("api/[controller]")]
    public class LunchController : Controller
    {
        private readonly IRestaurants _restaurants;

        public LunchController(IRestaurants restaurants) 
        {
            _restaurants = restaurants;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            var restaurant = _restaurants.GetByName("Snackviken");

            return await restaurant.GetMenu();
        }
    }
}
