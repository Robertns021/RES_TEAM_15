using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Common;
using Server;

namespace ResidentExecutor2
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IFunkcije> channel;
            IFunkcije proxy;

            channel = new ChannelFactory<IFunkcije>("ServiceFunkcije");
            proxy = channel.CreateChannel();
            proxy.FunkcijaMin();
            Console.ReadLine();
        }
    }
}
