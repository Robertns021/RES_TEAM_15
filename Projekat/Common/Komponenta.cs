using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;



namespace Common
{
    [DataContract]
    public class Komponenta
    {
        public static int last = 0;
        [DataMember]
        public int Id { get; }
        [DataMember]
        public string Naziv { get; set; } // placeholder polja
        [DataMember]
        public double Vrednost { get; set; }
        [DataMember]
        public DateTime vremeproracuna { get; set; }
        [DataMember]
        public DateTime poslednjevreme { get; set; }


        public Komponenta(string naziv = "", double vrednost = 0)
        {
            Id = last++;
            Naziv = naziv;
            Vrednost = vrednost;
        }
    }
}
