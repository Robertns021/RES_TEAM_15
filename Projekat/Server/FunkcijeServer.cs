using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using MySql.Data.MySqlClient;
using DataBase;

namespace Server
{
    class FunkcijeServer : IFunkcije
    {
        private DataAccess da;
        public void funkcija1(Komponenta k)
        {
            da.min(k);
        }

        public void funkcija2(Komponenta k)
        {
            da.max(k);
        }

        public void funkcija3(Komponenta k)
        {
            da.dev(k);
        }
    }
}
