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
using System.Globalization;

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
        public async Task<ScaniaRestaurant> GetByRestaurantId(int restaurantId, DateTime? date = null) 
        {
            var restaurant = _restaurants.GetById(restaurantId);
            var menu = await restaurant.GetMenu();

            var result = ScaniaRestaurantConverter.ConvertFrom(restaurant, menu);

            if (date.HasValue) {
                CultureInfo cul = CultureInfo.CurrentCulture;
                int weekNum = cul.Calendar.GetWeekOfYear(
                    date.Value,
                    CalendarWeekRule.FirstFullWeek,
                    DayOfWeek.Monday);

                var week = result.Weeks.FirstOrDefault(m => m.WeekNumber == weekNum);

                if (week != null)
                {
                    var dayMenu = week.Menus.FirstOrDefault(m => m.Date == date);
                    if (dayMenu != null) 
                    {
                        week.Menus = new List<ScaniaDay>() { dayMenu };
                        result.Weeks = new List<ScaniaWeek>() { week };
                    }
                    else {
                        result.Weeks = null;
                    }
                }
                else {
                    result.Weeks = null;
                }
            }

            return result;
        }
    }
}
