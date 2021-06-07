using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;



namespace Common
{
    [DataContract]
    public class Racunanje
    {
        public static int last = 0;
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Naziv { get; set; }
        [DataMember]
        public double Vrednost { get; set; }
        [DataMember]
        public DateTime VremeProracuna { get; set; }
        [DataMember]
        public DateTime PoslednjeVreme { get; set; }

        public Racunanje() { Id = last++; }

        public Racunanje(string naziv, double vrednost, DateTime vreme_proracuna, DateTime poslednje_vreme)
        {
            Id = last++;
            Naziv = naziv;
            Vrednost = vrednost;
            VremeProracuna = vreme_proracuna;
            PoslednjeVreme = poslednje_vreme;     
        }
    }
}
