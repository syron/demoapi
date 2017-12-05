using System;
using System.Collections.Generic;

namespace ScaniaDemo_restapi.Models
{
    public class ScaniaWeek
    {
        public int WeekNumber
        {
            get;
            set;
        }

        public IList<ScaniaDay> Days { get; set; }

        public ScaniaWeek()
        {
        }
    }
}
