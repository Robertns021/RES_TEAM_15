using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using Common;

namespace DAKlijent
{
    public class DataAccessKlijent
    {
        DataAccess da = new DataAccess();

        public void Upisi(string region, DateTime datum_vreme, double vrednost)
        {
            da.UpisiVrednostiZaRegion(region, datum_vreme, vrednost);
        }

        public List<Racunanje> Procitaj()
        {
            return da.DobaviRacunanja();
        }
    }
}
