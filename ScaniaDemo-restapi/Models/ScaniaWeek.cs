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

        public IList<ScaniaDay> Menus { get; set; }

        public ScaniaWeek()
        {
        }
    }
}
