using System;
using System.Collections.Generic;

namespace ScaniaDemo_restapi.Models
{
    public class Day
    {
        public string InfoText
        {
            get;
            set;
        }

        public string DayMenuDate
        {
            get;
            set;
        }

        public IList<DayMenu> DayMenus 
        {
            get;
            set;
        }

        public Day()
        {
        }
    }
}
