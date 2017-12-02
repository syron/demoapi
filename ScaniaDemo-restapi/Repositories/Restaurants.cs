using System;
using System.Linq;
using System.Collections.Generic;
using ScaniaDemo_restapi.Models;

namespace ScaniaDemo_restapi.Repositories
{
    public class Restaurants : IRestaurants
    {
        private List<Restaurant> _restaurants { get; set; }

        public Restaurants() {
            _restaurants = new List<Restaurant>();

            _restaurants.Add(new Restaurant(1, "Chassi", "https://eurest.mashie.com/public/menu/syd/0711f488?country=se"));
            _restaurants.Add(new Restaurant(2, "Syd", "https://eurest.mashie.com/public/menu/syd/0711f488?country=se"));
            _restaurants.Add(new Restaurant(3, "Snackviken", "https://eurest.mashie.com/public/menu/syd/0711f488?country=se"));
            _restaurants.Add(new Restaurant(4, "Sjokringlan", "https://eurest.mashie.com/public/menu/syd/0711f488?country=se"));
            _restaurants.Add(new Restaurant(5, "Stalhamnra", "https://eurest.mashie.com/public/menu/syd/0711f488?country=se"));
            _restaurants.Add(new Restaurant(6, "Restaurang270", "https://eurest.mashie.com/public/menu/syd/0711f488?country=se"));
        }

        public Restaurant GetById(int id) {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public Restaurant GetByName(string name) {
            return _restaurants.FirstOrDefault(r => r.Name == name);
        }
    }
}