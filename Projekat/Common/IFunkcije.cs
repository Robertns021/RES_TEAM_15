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
        Racunanje FunkcijaMin(); //Upisuje se vreme pa potrosnja

        [OperationContract]
        Racunanje FunkcijaMax(); //Upisuje se vreme pa potrosnja

        [OperationContract]
        Racunanje FunkcijaAvg(); //Upisuje se vreme pa potrosnja
    }
}
