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

        // GET: api/values
        [HttpGet]
        public async Task<string> Get()
        {
            return await GetMenu(_restaurants.GetByName("Snackviken").Url);
        }

        private async Task<string> GetMenu(string url) {
            var client = new HttpClient();
            HttpResponseMessage result = await client.GetAsync(url);
            Stream stream = await result.Content.ReadAsStreamAsync();

            HtmlDocument doc = new HtmlDocument();
            doc.Load(stream);

            HtmlNodeCollection links = doc.DocumentNode.SelectNodes("//script");
            var lunchData = links.First().InnerHtml;

            var indexOfFirstWing = lunchData.IndexOf('{');
            var newData = lunchData.Substring(indexOfFirstWing, lunchData.Length - 2 - indexOfFirstWing);
            newData = WebUtility.HtmlDecode(newData);

            var regex = @"new Date\([0-9]{1,}\)"; // finds all "new Date(123)"

            var match = Regex.Match(newData, regex);
            while (match.Success)
            {
                var val = match.Value;

                var intRegex = @"[0-9]{1,}";
                var intMatch = Regex.Match(val, intRegex);

                var initialValue = string.Empty;
                var newValue = string.Empty;
                while (intMatch.Success)
                {
                    initialValue = intMatch.Value;
                    var timespan = TimeSpan.FromMilliseconds(long.Parse(initialValue));
                    var date = new DateTime(1970, 1, 1);
                    date = date.AddMilliseconds(long.Parse(initialValue)).AddHours(2);
                    newValue = date.ToString("yyyyMMdd");

                    intMatch = intMatch.NextMatch(); // hopefully just one iteration... if not, something is fishy!
                }

                newData = newData.Replace(val, "\"" + newValue + "\"");

                match = match.NextMatch();
            }
            return newData;
        }
    }
}
