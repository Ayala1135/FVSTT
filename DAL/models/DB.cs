using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.models
{
    public class DB
    {
        
        public static List<City> ListCities;
       
        public static List<Street> ListStreets;
     
        private static DB instance;
        private DB()
        {
            ListStreets = new List<Street>();
            ListStreets.Add(new Street("Reuven"));
            ListStreets.Add(new Street("Levi"));
            ListStreets.Add(new Street("Yeuda"));
            ListStreets.Add(new Street("Gad"));
            ListStreets.Add(new Street("Dan"));
            ListCities = new List<City>();
            HashSet<Street> streets = new HashSet<Street>();
            streets.Add(ListStreets[0]);
            ListCities.Add(new City("Beit Shemesh", streets));
            streets.Add(ListStreets[1]);
            streets.Add(ListStreets[2]);
            ListCities.Add(new City("Jerusalem", streets));
            streets.Add(ListStreets[3]);
            streets.Add(ListStreets[4]);
            ListCities.Add(new City("Tel Aviv", streets));
        }
        public static DB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DB();
                }
                return instance;
            }
        }
    }
}
