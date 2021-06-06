using Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResidentExecutor
{
    class REA
    {
        readonly int vreme = Convert.ToInt32(ConfigurationManager.AppSettings["vreme"]);
        readonly bool f1 = Convert.ToBoolean(ConfigurationManager.AppSettings["f1"]);
        readonly bool f2 = Convert.ToBoolean(ConfigurationManager.AppSettings["f2"]);
        readonly bool f3 = Convert.ToBoolean(ConfigurationManager.AppSettings["f3"]);

        ChannelFactory<IFunkcije> channel = new ChannelFactory<IFunkcije>("ServiceFunkcije");
        IFunkcije proxy;
        Merenje m = new Merenje();

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
                    proxy.funkcija1(m);
                if (f2)
                    proxy.funkcija2(m);
                if (f3)
                    proxy.funkcija3(m);

                Console.WriteLine($"pauza {vreme / 1000} sekundi \n\n");
                Thread.Sleep(vreme);
            }
        }
    }
}
