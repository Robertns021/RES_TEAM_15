using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IDataAccess
    {
        void UpisiURacunanja(IRacunanje temp);

        void OdrediId();

        void UpisiVrednostiZaRegion(string region, DateTime datum_vreme, double vrednost);

        List<Merenje> DobaviMerenja();

        List<Racunanje> DobaviRacunanja();

        DateTime DobaviPoslednjeVreme();
    }
}
