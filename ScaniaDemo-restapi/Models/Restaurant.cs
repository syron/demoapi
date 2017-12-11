using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json;

namespace ScaniaDemo_restapi.Models
{
	public class Restaurant
    {
        public Restaurant()
        {
        }

        public Restaurant(int id, string name, string displayName, string url) 
        {
            Id = id;
            Name = name;
            DisplayName = displayName;
            Url = url;
        }

        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

<<<<<<< HEAD
        public string DisplayName {
=======
        public string DisplayName
        {
>>>>>>> 7346f118c5b9de115c9568d11e1f6e6d6a68891c
            get;
            set;
        }

        public string Url
        {
            get;
            set;
        }

        public async Task<WeeklyMenu> GetMenu()
        {
            var client = new HttpClient();
            HttpResponseMessage result = await client.GetAsync(Url);
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

            return JsonConvert.DeserializeObject<WeeklyMenu>(newData);
        }
    }
}
