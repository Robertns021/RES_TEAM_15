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
        int funkcija1(string a, double b); //Upisuje se vreme pa potrosnja

        [OperationContract]
        int funkcija2(string a, double b); //Upisuje se vreme pa potrosnja

        [OperationContract]
        int funkcija3(string a, double b); //Upisuje se vreme pa potrosnja
    }
}
