using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
    public class Komponenta
    {
        public static int last = 0;
        public int Id { get; }
        public string Naziv { get; set; } // placeholder polja
        public double Vrednost { get; set; }

        public Komponenta(string naziv = "", double vrednost = 0)
        {
            Id = last++;
            Naziv = naziv;
            Vrednost = vrednost;
        }
    }
}
