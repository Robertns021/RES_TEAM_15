using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DataContract]
    public class Merenje
    {
        public static int last = 0;
        [DataMember]
        public int Id { get; }
        [DataMember]
        public string Naziv { get; set; }
        [DataMember]
        public double Vrednost { get; set; }
        [DataMember]
        public DateTime Vreme { get; set; }


        public Merenje(string naziv = "", double vrednost = 0)
        {
            Id = last++;
            Naziv = naziv;
            Vrednost = vrednost;
            Vreme = DateTime.Now;
        }

    }
}
