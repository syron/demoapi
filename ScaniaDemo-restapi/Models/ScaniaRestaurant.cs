using System;
using System.Collections.Generic;

namespace ScaniaDemo_restapi.Models
{
    public class ScaniaMenu
    {
        public Restaurant Restaurant
        {
            get;
            set;
        }
   
        public IList<ScaniaWeek> Weeks { get; set}

        public ScaniaMenu()
        {
        }
    }
}
