using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IStreetDAL
    {
        bool AddStreet(string nameNewStreet);
        bool AddStreetToSpesificCity(string nameNewStreet, string nameCity);
    }
}
