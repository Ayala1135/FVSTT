using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.models;

namespace DAL
{
    public class StreetDAL : IStreetDAL
    {
        public StreetDAL()
        {
            DB DB = DB.Instance;
        }
        public bool AddStreet(string nameNewStreet)
        {

            //בדיקת תקינות האם קיים כבר רחוב בשם זה
            if (DB.ListStreets.FirstOrDefault(r => r.nameStreet == nameNewStreet) == null)
            {
                DB.ListStreets.Add(new Street(nameNewStreet));
                return true;
            }
            return false;
        }

        public bool AddStreetToSpesificCity(string nameNewStreet, string nameCity)
        {
            //When add item to HashSet if the item already exists the function add return false else it return true
            return DB.ListCities.FirstOrDefault(a => a.nameCity == nameCity).MyStreets.Add(new Street(nameNewStreet));
        }
    }
}
