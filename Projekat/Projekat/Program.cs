using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ResidentExecutor;
using Common;
using DAKlijent;

namespace Projekat
{
    class Program
    {
        static void Main(string[] args)
        {
            DataAccessKlijent dak = new DataAccessKlijent();
            Random rand = new Random();
            List<string> lista = new List<string> { "beograd", "novi sad", "nis", "sombor" };

            while (true)
            {
                dak.Upisi(lista[rand.Next(0,lista.Count())], DateTime.Now, rand.Next(0, 300));
                List<Racunanje> racun = dak.Procitaj();
                foreach (var item in racun)
                {
                    Console.WriteLine("vrednost = " + item.Vrednost.ToString() +"\ndatum = " + item.VremeProracuna.ToString() + "\n");
                }
                Console.WriteLine("pauza 2 sekunde\n\n");
                Thread.Sleep(5000);
            }
            // Console.ReadKey();
        }
    }
}
