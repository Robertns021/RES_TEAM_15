using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Common;

namespace ResidentExecutor
{
    class Program
    {
        static void Main(string[] args)
        {

            int vreme = 1000;
            bool f1 = true;
            bool f2 = true;
            bool f3 = true;


            ChannelFactory<IFunkcije> channel;
            IFunkcije proxy;

            channel = new ChannelFactory<IFunkcije>("ServiceFunkcije");
            vreme = Convert.ToInt32(ConfigurationManager.AppSettings["vreme"]);
            f1 = Convert.ToBoolean(ConfigurationManager.AppSettings["f1"]);
            f2 = Convert.ToBoolean(ConfigurationManager.AppSettings["f2"]);
            f3 = Convert.ToBoolean(ConfigurationManager.AppSettings["f3"]);
            proxy = channel.CreateChannel();
            proxy.FunkcijaMin();
            Console.ReadLine();

            Thread t = new Thread(Process);
            t.IsBackground = true;
            t.Start();

            void Process()
            {
                proxy = channel.CreateChannel();
                while (true)
                {
                    try
                    {
                        if (f1)
                            UpisiULogFunkcija(proxy.FunkcijaMin());
                        if (f2)
                            UpisiULogFunkcija(proxy.FunkcijaMax());
                        if (f3)
                            UpisiULogFunkcija(proxy.FunkcijaAvg());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.WriteLine($"pauza {vreme / 1000} sekundi \n\n");
                    Thread.Sleep(vreme);
                }
            }

            string DobaviLogFunkcija()
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

            bool UpisiULogFunkcija(Racunanje racunanje)
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

            //Nacin upisivSqlConnectioanja u DB za svaku tabelu su prva dva parametra ista a poslednji se menja
            /*Myn con = new MySqlConnection("server = localhost; user id = root; password = root; database = res_team_15");
            MySqlCommand cmd = new MySqlCommand("insert into funkcija1(vreme_proracuna, poslednje_merenje, prosecna_potrosnja) values('2021-12-31 23:59:59', '2021-12-31 23:59:59', 13.5)", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();*/

            //string fileName = @"C:\Users\Ivica\RES_TEAM_15\Projekat\Server\App.config";
            //XmlDocument doc = new XmlDocument();
            //doc.Load(fileName);
            // XmlNode node = doc.SelectSingleNode("//vreme");
            // XmlNodeList nodeL = doc.SelectNodes("/configuration/appSettings");
            //int vreme = Int16.Parse(node.Value);
            // vreme = Int16.Parse(nodeL.Item(0).Value);      
        }
    }
}
