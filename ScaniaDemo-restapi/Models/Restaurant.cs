using System;
namespace ScaniaDemo_restapi.Models
{
	public class Restaurant
    {
        public Restaurant()
        {
        }

        public Restaurant(int id, string name, string url) 
        {
            Id = id;
            Name = name;
            Url = url;
        }

        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Url
        {
            get;
            set;
        }
    }
}
