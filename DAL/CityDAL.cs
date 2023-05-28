using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.models;

namespace DAL
{
    public class CityDAL : ICityDAL
    {
        public CityDAL()
        {
            DB DB = DB.Instance;
        }

        public List<City> GetCities()
        {
            return DB.ListCities;
        }
        public HashSet<Street> GetAllStreetsOfCityByIdCity(int _idCity)
        {
            //בדיקת תקינות שאכן יש עיר כזו ויש לה רחובות להצגה
            if (DB.ListCities.FirstOrDefault(a => a.idCity == _idCity) == null || DB.ListCities.FirstOrDefault(a => a.idCity == _idCity).MyStreets.Count == 0)
                return null;
            return DB.ListCities.FirstOrDefault(a => a.idCity == _idCity).MyStreets;
        }
        public List<City> AddCity(string nameNewCity)
        {
            //בדיקת תקינות האם קיים עיר בשם זה כבר
            if (DB.ListCities.FirstOrDefault(a => a.nameCity == nameNewCity) == null)
                DB.ListCities.Add(new City(nameNewCity));
            return DB.ListCities;
        }


    }
}
