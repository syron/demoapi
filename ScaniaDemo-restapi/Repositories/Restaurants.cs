using System;
using System.Linq;
using System.Collections.Generic;
using ScaniaDemo_restapi.Models;

namespace ScaniaDemo_restapi.Repositories
{
    public class Restaurants : IRestaurants
    {
        private List<Restaurant> _restaurants { get; set; }

        public Restaurants()
        {
            _restaurants = new List<Restaurant>();

            _restaurants.Add(new Restaurant(1, "Chassi", "https://eurest.mashie.com/public/menu/chassi/4445da66?country=se")); //Done
            _restaurants.Add(new Restaurant(2, "Syd", "https://eurest.mashie.com/public/menu/syd/0711f488?country=se")); //Done
            _restaurants.Add(new Restaurant(3, "RestaurangSSE", "https://eurest.mashie.com/public/menu/chassi/9628a022?country=se")); //Done
            _restaurants.Add(new Restaurant(4, "Sjokringlan", "https://eurest.mashie.com/public/menu/Sj%C3%B6kringlan/50D2C169?country=se")); //Done
            _restaurants.Add(new Restaurant(5, "Stalhamnra", "https://eurest.mashie.com/public/menu/st%C3%A5lhamra/9986abfd?country=se")); //Done
            _restaurants.Add(new Restaurant(6, "Restaurang270", "https://eurest.mashie.com/public/menu/270/663dc8bf?country=se")); //Done
            _restaurants.Add(new Restaurant(7, "Granpark", "https://eurest.mashie.com/public/menu/granpark/b4c46dcd?country=se")); //Done
            _restaurants.Add(new Restaurant(8, "Karpen", "https://eurest.mashie.com/public/menu/Sjökringlan/50D2C169?country=se")); //Done
            _restaurants.Add(new Restaurant(9, "Motorkringlan", "https://eurest.mashie.com/public/menu/motorkringlan/12128ca7?country=se")); //Done
            _restaurants.Add(new Restaurant(10, "Snäckviken", "https://eurest.mashie.com/public/menu/sn%C3%A4ckviken/bad07c57?country=se"));
        }

        public IList<Restaurant> GetAll()
        {
            return _restaurants;
        }

        public Restaurant GetById(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public Restaurant GetByName(string name)
        {
            return _restaurants.FirstOrDefault(r => r.Name == name);
        }
    }
}