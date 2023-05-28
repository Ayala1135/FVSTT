using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.models
{
    public class City
    {
        private static int _idCity = 100;
        public int idCity { get; set; }
        public string nameCity { get; set; }
        public HashSet<Street> MyStreets { get; set; }
        public City(string nameCity, HashSet<Street> MyStreets)
        {
            this.MyStreets = MyStreets;
            this.nameCity = nameCity;
            idCity = _idCity++;
        }
        public City(string nameCity)
        {
            idCity = _idCity++;
            this.nameCity = nameCity;
            MyStreets = new HashSet<Street>();
        }
    }
}
