using System;
using System.Linq;
using System.Collections.Generic;
using ScaniaDemo_restapi.Models;

namespace ScaniaDemo_restapi.Repositories
{
    public interface IRestaurants
    {
        IList<Restaurant> GetAll();

        Restaurant GetById(int id);

        Restaurant GetByName(string name);
    }
}