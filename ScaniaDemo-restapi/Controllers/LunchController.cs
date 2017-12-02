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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScaniaDemo_restapi.Controllers
{
    public static class ScaniaRestaurants
    {
        public const string Syd = "https://eurest.mashie.com/public/menu/syd/0711f488?country=se";
        public const string Snackviken = "https://eurest.mashie.com/public/menu/sn%C3%A4ckviken/bad07c57?country=se";
        public const string Sjokringlan = "https://eurest.mashie.com/public/menu/sj%C3%B6kringlan/9104e9a0?country=se";
        public const string Stalhamnra = "https://eurest.mashie.com/public/menu/st%C3%A5lhamra/9986abfd?country=se";
        public const string Restaurang270 = "https://eurest.mashie.com/public/menu/270/663dc8bf?country=se";
        public const string Chassi = "https://eurest.mashie.com/public/menu/chassi/4445da66?country=se";
    }

    [Route("api/[controller]")]
    public class LunchController : Controller
    {
        // GET: api/values
        [HttpGet]
        public async Task<string> Get()
        {
            
            return await GetMenu(ScaniaRestaurants.Snackviken);
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
