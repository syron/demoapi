using System;
using System.Collections.Generic;

namespace ScaniaDemo_restapi.Models
{
    public class ScaniaDay
    {
        public DateTime Date { get; set; }
        public IList<ScaniaMeal> Meals { get; set; }

        public ScaniaDay()
        {
        }
    }
}
