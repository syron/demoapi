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
using ScaniaDemo_restapi.Converter;

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
        [Route("{restaurantId}")]
        public async Task<ScaniaRestaurant> GetByRestaurantId(int restaurantId) 
        {
            var restaurant = _restaurants.GetById(restaurantId);
            var menu = await restaurant.GetMenu();
            return ScaniaRestaurantConverter.ConvertFrom(restaurant, menu);
        }
    }
}
