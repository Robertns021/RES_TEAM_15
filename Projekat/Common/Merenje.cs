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
        [DataMember]
        public string Naziv { get; set; }
        [DataMember]
        public double Vrednost { get; set; }
        [DataMember]
        public DateTime Vreme { get; set; }


        public Merenje(string naziv = "", double vrednost = 0)
        {
            Naziv = naziv;
            Vrednost = vrednost;
            Vreme = DateTime.Now;
        }

    }
}
