using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Server
{
    class FunkcijeServer : IFunkcije
    {
        public int funkcija1(int a, int b)
        {
            return a + b;
        }

        public int funkcija2(int a, int b)
        {
            return (a + b) / 2;
        }

        public int funkcija3(int a, int b)
        {
            return a - b;
        }
    }
}
