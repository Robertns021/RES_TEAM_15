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
        int funkcija1(int a, int b); //Upisuje se vreme pa potrosnja

        [OperationContract]
        int funkcija2(int a, int b); //Upisuje se vreme pa potrosnja

        [OperationContract]
        int funkcija3(int a, int b); //Upisuje se vreme pa potrosnja
    }
}
