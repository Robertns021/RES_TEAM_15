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
        void funkcija1(Komponenta k); //Upisuje se vreme pa potrosnja

        [OperationContract]
        void funkcija2(Komponenta k); //Upisuje se vreme pa potrosnja

        [OperationContract]
        void funkcija3(Komponenta k); //Upisuje se vreme pa potrosnja
    }
}
