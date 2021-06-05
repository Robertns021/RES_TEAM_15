﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Common;
using MySql.Data.MySqlClient;

namespace ResidentExecutor
{
    class Program
    {
        static void Main(string[] args)
        {
            //Nacin upisivanja u DB za svaku tabelu su prva dva parametra ista a poslednji se menja
            /*MySqlConnection con = new MySqlConnection("server = localhost; user id = root; password = root; database = res_team_15");
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

            int vreme = Convert.ToInt32(ConfigurationManager.AppSettings["vreme"]);

            ChannelFactory<IFunkcije> channel = new ChannelFactory<IFunkcije>("ServiceFunkcije");
            IFunkcije proxy = channel.CreateChannel();

            while (true)
            {
                Console.WriteLine("a = 5, b = 6 \n");
                Console.WriteLine($"a+b = {proxy.funkcija1(5, 6)}\n");
                Console.WriteLine($"(a+b)/2 = {proxy.funkcija2(5, 6)}\n");
                Console.WriteLine($"a-b = {proxy.funkcija3(5, 6)}\n\n");
                Console.WriteLine($"pauza {vreme/1000} sekundi \n\n");
                Thread.Sleep(vreme);
            }
        }
    }
}
