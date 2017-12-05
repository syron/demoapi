using System;
namespace ScaniaDemo_restapi.Models
{
    public class DayMenu
    {
        public Guid PortionTypeId
        {
            get;
            set;
        }

        public bool HasExtendedInfo
        {
            get;
            set;
        }

        public string MealPictureURL
        {
            get;
            set;
        }

        public string MenuAlternativeMenu 
        {
            get;
            set;
        }

        public string DayMenuInfo
        {
            get;
            set;
        }

        public Guid? MealId
        {
            get;
            set;
        }

        public bool ShowDayNutrient
        {
            get;
            set;
        }

        public bool ShowWeekNutrient
        {
            get;
            set;
        }

        public bool ShowIngredients
        {
            get;
            set;
        }

        public bool ShowAllergens
        {
            get;
            set;
        }

        public bool ShowClassifications
        {
            get;
            set;
        }

        public MenuPresentation MenuPresentation
        {
            get;
            set;
        }
     
        public DayMenu()
        {
        }
    }
}
