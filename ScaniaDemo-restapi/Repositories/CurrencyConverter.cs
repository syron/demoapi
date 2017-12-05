using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ScaniaDemo_restapi.Repositories
{
    public class CurrencyConverter : ICurrencyConverter
    {
        public CurrencyConverter()
        {
        }

        public async Task<string> GetCurrencies(string paramBase = "") {
            var url = "https://api.fixer.io/latest";

            if (!string.IsNullOrWhiteSpace(paramBase)) {
                url = $"{url}?base={paramBase}";
            }

            var client = new HttpClient();

            return await client.GetStringAsync(url);
        }
    }
}