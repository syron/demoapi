using System;
namespace ScaniaDemo_restapi.Models
{
    public class MenuPresentation
    {
        public int DayMenuWeek { get; set; }
        public string DayMenuDate { get; set; }
        public int WeekType { get; set; }
        public Guid? OrgId { get; set; }
        public string MenuAlternativeName { get; set; }
        public int? MenuAlternativeOrder { get; set; }
        public string DayMenuInfo { get; set; }
        public string DayMenuName { get; set; }
        public Guid? PortionTypeId { get; set; }
        public Guid? MealId { get; set; }
        public Guid? MealPictureId { get; set; }
        public string MealPictureFormat { get; set; }
        public bool ShowDayNutrient { get; set; }
        public bool ShowWeekNutrient { get; set; }
        public bool ShowIngredients { get; set; }
        public bool ShowAllergens { get; set; }
        public bool ShowClassifications { get; set; }
        public Guid? MenuId { get; set; }

        public MenuPresentation()
        {
        }
    }
}
