using System;
using System.Collections.Generic;

namespace ScaniaDemo_restapi.Models
{
    public class ScaniaRestaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
   
        public IList<ScaniaWeek> Weeks { get; set}

        public ScaniaRestaurant()
        {
        }
    }
}
