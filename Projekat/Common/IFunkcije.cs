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
        void funkcija1(string a, double b); //Upisuje se vreme pa potrosnja

        [OperationContract]
        void funkcija2(string a, double b); //Upisuje se vreme pa potrosnja

        [OperationContract]
        void funkcija3(string a, double b); //Upisuje se vreme pa potrosnja
    }
}
