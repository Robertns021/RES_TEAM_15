using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Xml;
using Common;
using FunkcijeProjekat;
using DataBase;

namespace ResidentExecutor
{
    class Program
    {
        static void Main(string[] args)
        {
            Funkcije f = new Funkcije();
            IDataAccess da = new DataAccess();
            IRacunanje ra = new Racunanje();

            int vreme = Convert.ToInt32(ConfigurationManager.AppSettings["vreme"]);
            bool f1 = Convert.ToBoolean(ConfigurationManager.AppSettings["f1"]);
            bool f2 = Convert.ToBoolean(ConfigurationManager.AppSettings["f2"]);
            bool f3 = Convert.ToBoolean(ConfigurationManager.AppSettings["f3"]);
           
            while (true)
            {
                try
                {
                    if (f1)
                        UpisiULogFunkcija(f.FunkcijaMin(da,ra));
                    if (f2)
                        UpisiULogFunkcija(f.FunkcijaMax(da,ra));
                    if (f3)
                        UpisiULogFunkcija(f.FunkcijaAvg(da,ra));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine(DobaviLogFunkcija() + "\n\n");
                Console.WriteLine($"pauza {vreme / 1000} sekundi \n\n");
                Thread.Sleep(vreme);
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

        static string DobaviLogFunkcija()
        {
            string str = "";

            string putanja = @"C:\Users\Ivica\RES_TEAM_15\Projekat\ResidentExecutor\Log\";

            using (StreamReader sr = new StreamReader(putanja + @"\LogFunkcija.txt"))
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

        static bool UpisiULogFunkcija(IRacunanje racunanje)
        {
            if (racunanje == null)
                return false;

            string putanja = @"C:\Users\Ivica\RES_TEAM_15\Projekat\ResidentExecutor\Log\";

            using (StreamWriter sw = File.AppendText(putanja + @"\LogFunkcija.txt"))
            {
                string linija = "";
                linija += racunanje.Id.ToString() + ";";
                linija += racunanje.Naziv + ";";
                linija += racunanje.PoslednjeVreme + ";";
                linija += racunanje.VremeProracuna + ";";
                linija += racunanje.Vrednost + ";";

                sw.WriteLine(linija);

                sw.Close();
            }
            return true;
        }
    }
}
