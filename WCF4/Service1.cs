using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace WCF4
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class Service1 : IService1
    {
        public void Funkcja1(string s1)
        {
            Console.WriteLine("...{0}: funkcja1 - start", s1);
            Thread.Sleep(3000);
            Console.WriteLine("...{0}: funkcja1 - stop", s1);
            return;
        }

        public void Funkcja2(string s2)
        {
            Console.WriteLine("...{0}: funkcja2 - start", s2);
            Thread.Sleep(3000);
            Console.WriteLine("...{0}: funkcja2 - stop", s2);
            return;
        }
    }
}
