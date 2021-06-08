using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{

    public interface IFunkcije
    {
        IRacunanje FunkcijaMin(IDataAccess da,IRacunanje r); //Upisuje se vreme pa potrosnja

        IRacunanje FunkcijaMax(IDataAccess da,IRacunanje r); //Upisuje se vreme pa potrosnja

        IRacunanje FunkcijaAvg(IDataAccess da,IRacunanje r); //Upisuje se vreme pa potrosnja
    }
}
