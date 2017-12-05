using System;
using System.Collections.Generic;

namespace ScaniaDemo_restapi.Models
{
    public class WeeklyMenu
    {
        public IList<Menu> Weeks
        {
            get;
            set;
        }

        public Guid? PortionTypeId
        {
            get;
            set;
        }

        public int CurrentWeek
        {
            get;
            set;
        }

        public string MenuPresInfoText
        {
            get;
            set;
        }

        public Guid? MenuId
        {
            get;
            set;
        }

        public WeeklyMenu()
        {
        }
    }
}
