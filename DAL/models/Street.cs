using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.models
{
    public class Street
    {
        private static int _idStreet = 100;
        public int idStreet { get; set; }
        public string nameStreet { get; set; }
        public Street(string nameStreet)
        {
            this.nameStreet = nameStreet;
            idStreet = _idStreet++;
        }
    }
}
