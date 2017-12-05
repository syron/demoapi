using System;
using System.Collections.Generic;

namespace ScaniaDemo_restapi.Models
{
    public class Menu
    {
        public Guid? MenuId
        {
            get;
            set;
        }

        public string MenuName
        {
            get;
            set;
        }

        public int WeekNumber
        {
            get;
            set;
        }

        public IList<Day> Days 
        {
            get;
            set;
        }

        public Menu()
        {
        }
    }
}
