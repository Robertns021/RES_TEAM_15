using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;



namespace Common
{
    public class Racunanje : IRacunanje
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public double Vrednost { get; set; }
        public DateTime VremeProracuna { get; set; }
        public DateTime PoslednjeVreme { get; set; }

        public Racunanje() { Id = 0; }

        public Racunanje(string naziv, double vrednost, DateTime vreme_proracuna, DateTime poslednje_vreme)
        {
            Id = 0;
            Naziv = naziv;
            Vrednost = vrednost;
            VremeProracuna = vreme_proracuna;
            PoslednjeVreme = poslednje_vreme;     
        }
    }
}
