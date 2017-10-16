using System;

namespace ScaniaDemo_restapi.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Truck
    {
        public int ModelId
        {
            get;
            set;
        }
        public string RegistrationNumber
        {
            get;
            set;
        }
        public double Km 
        {
            get;
            set;
        }
        public string Driver 
        {
            get;
            set;
        }
    }
}