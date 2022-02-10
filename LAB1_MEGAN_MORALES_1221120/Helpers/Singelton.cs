using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LAB1_MEGAN_MORALES_1221120.Models;

namespace LAB1_MEGAN_MORALES_1221120.Helpers
{
    public class Singelton
    {
        private static Singelton _instance = null;

        public static Singelton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Singelton();
                }
                return _instance;
            }
        }

        public List<ClientModel> ClientList = new List<ClientModel>();


    }
}
