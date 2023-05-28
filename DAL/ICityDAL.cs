using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.models;

namespace DAL
{
    public interface ICityDAL
    {
        List<City> GetCities();
        HashSet<Street> GetAllStreetsOfCityByIdCity(int _idCity);
        List<City> AddCity(string nameNewCity);
    }
}
