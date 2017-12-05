using System;
using System.Collections.Generic;
using System.Globalization;
using ScaniaDemo_restapi.Models;

namespace ScaniaDemo_restapi.Converter
{
    public static class ScaniaRestaurantConverter
    {
        public static ScaniaRestaurant ConvertFrom(Restaurant restaurant, WeeklyMenu menu) 
        {
            ScaniaRestaurant scaniaRestaurant = new ScaniaRestaurant();
            scaniaRestaurant.RestaurantId = restaurant.Id;
            scaniaRestaurant.Name = restaurant.Name;

            scaniaRestaurant.Weeks = new List<ScaniaWeek>();

            int index = 0;
            foreach (var week in menu.Weeks) {
                if (index == 0) 
                    scaniaRestaurant.DisplayName = week.MenuName;

                var scaniaWeek = new ScaniaWeek();
                scaniaWeek.WeekNumber = week.WeekNumber;
                scaniaWeek.Days = new List<ScaniaDay>();

                foreach (var day in week.Days) {
                    ScaniaDay scaniaDay = new ScaniaDay();
                    scaniaDay.Date = DateTime.ParseExact(day.DayMenuDate, "yyyyMMdd", CultureInfo.InvariantCulture);
                    scaniaDay.Meals = new List<ScaniaMeal>();

                    foreach (var dayMenu in day.DayMenus) {
                        ScaniaMeal meal = new ScaniaMeal();
                        meal.AlternativeName = dayMenu.MenuPresentation.MenuAlternativeName;
                        meal.Name = dayMenu.MenuPresentation.DayMenuName;
                        scaniaDay.Meals.Add(meal);
                    }
                    scaniaWeek.Days.Add(scaniaDay);
                }
                scaniaRestaurant.Weeks.Add(scaniaWeek);

                index++;
            }

            return scaniaRestaurant;
        }
    }
}
