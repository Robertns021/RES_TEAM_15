using System;
using System.Collections.Generic;
using System.Configuration;
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
