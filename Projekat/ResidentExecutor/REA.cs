using Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResidentExecutor
{
    public class REA
    {
        readonly int vreme = Convert.ToInt32(ConfigurationManager.AppSettings["vreme"]);
        readonly bool f1 = Convert.ToBoolean(ConfigurationManager.AppSettings["f1"]);
        readonly bool f2 = Convert.ToBoolean(ConfigurationManager.AppSettings["f2"]);
        readonly bool f3 = Convert.ToBoolean(ConfigurationManager.AppSettings["f3"]);
        

        ChannelFactory<IFunkcije> channel = new ChannelFactory<IFunkcije>("ServiceFunkcije");
        IFunkcije proxy;

        public REA()
        {
            proxy = channel.CreateChannel();
        }

        public void Execute()
        {
            Thread t = new Thread(Process);
            t.IsBackground = true;
            t.Start();
        }

        private void Process()
        {
            while (true)
            {
                if (f1)
                    UpisiULogFunkcija(proxy.funkcijaMin());
                if (f2)
                    UpisiULogFunkcija(proxy.funkcijaMax());
                if (f3)
                    UpisiULogFunkcija(proxy.funkcijaAvg());

                Console.WriteLine($"pauza {vreme / 1000} sekundi \n\n");
                Thread.Sleep(vreme);
            }
        }

        public string DobaviLogFunkcija()
        {
            string str = "";

            string putanja = @"C:C:\Users\Ivica\RES_TEAM_15\Projekat\ResidentExecutor\Log\";

            using (StreamReader sr = new StreamReader(putanja + @"LogFunkcija.txt"))
            {
                string linija;
                while ((linija = sr.ReadLine()) != null)
                {
                    str = str + linija;
                }
                sr.Close();
            }



            return str;
        }

        private bool UpisiULogFunkcija(Racunanje racunanje)
        {
            if (racunanje == null)
                return false;

            string putanja = @"C:\Users\Ivica\RES_TEAM_15\Projekat\ResidentExecutor\Log\";

            using (StreamWriter sw = new StreamWriter(putanja + @"\LogFunkcija.txt"))
            {
                string linija = "";
                linija += racunanje.Id.ToString() + ";";
                linija += racunanje.Naziv + ";";
                linija += racunanje.PoslednjeVreme + ";";
                linija += racunanje.VremeProracuna + ";";

                sw.WriteLine(linija);

                sw.Close();
            }
            return true;
        }
    }
}
