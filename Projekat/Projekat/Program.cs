using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
    class Program
    {
        static void Main(string[] args)
        {
            DataAccess DA = new DataAccess();
            Komponenta k = new Komponenta();
            DA.Create(2, k);
            DA.Read(2);
            DA.Update(2, 5);
            DA.Delete(2);
            Console.ReadKey();
        }
    }
}
