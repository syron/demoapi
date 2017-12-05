using System;
using System.Threading.Tasks;

namespace ScaniaDemo_restapi.Repositories
{
    public interface ICurrencyConverter
    {
        Task<string> GetCurrencies(string paramBase = "");
    }
}
