using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Common
{
    [ServiceContract]
    public interface IFunkcije
    {
        [OperationContract]
        Racunanje funkcijaMin(); //Upisuje se vreme pa potrosnja

        [OperationContract]
        Racunanje funkcijaMax(); //Upisuje se vreme pa potrosnja

        [OperationContract]
        Racunanje funkcijaAvg(); //Upisuje se vreme pa potrosnja
    }
}
