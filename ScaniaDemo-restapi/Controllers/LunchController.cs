using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScaniaDemo_restapi.Controllers
{
    [Route("api/[controller]")]
    public class LunchController : Controller
    {
        // GET: api/values
        [HttpGet]
        public async Task<string> Get()
        {
            var url = "https://eurest.mashie.com/public/menu/sn%C3%A4ckviken/bad07c57?country=se";

            var client = new HttpClient();
            HttpResponseMessage result = await client.GetAsync(url); 
            Stream stream = await result.Content.ReadAsStreamAsync(); 

            HtmlDocument doc = new HtmlDocument(); 
            doc.Load(stream);

            HtmlNodeCollection links = doc.DocumentNode.SelectNodes("//script");
            var lunchData = links.First().InnerHtml;

            var indexOfFirstWing = lunchData.IndexOf('{');
            var newData = lunchData.Substring(indexOfFirstWing, lunchData.Length - 2 - indexOfFirstWing);

            return WebUtility.HtmlDecode(newData);
        }
    }
}
