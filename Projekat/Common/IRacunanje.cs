using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IRacunanje
    {
        int Id { get; set; }
        string Naziv { get; set; }
        double Vrednost { get; set; }
        DateTime VremeProracuna { get; set; }
        DateTime PoslednjeVreme { get; set; }
    }
}
