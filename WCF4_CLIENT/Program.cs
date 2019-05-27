using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WCF4_CLIENT.ServiceReference1;
using WCF4_CLIENT.ServiceReference2;

namespace WCF4_CLIENT
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1Client client = new Service1Client("WSHttpBinding_IService1");
            Console.WriteLine("... wywolano funkcja1");
            client.Funkcja1("Klient1");
            Thread.Sleep(10);
            Console.WriteLine(".. kontynuacja po funkcja1");
            Console.WriteLine("... wywolano funkcja2");
            client.Funkcja2("Klient1");
            Thread.Sleep(10);
            Console.WriteLine(".. kontynuacja po funkcja2");
            Console.WriteLine("... wywolano funkcja1");
            client.Funkcja1("Klient1");
            Thread.Sleep(10);
            Console.WriteLine(".. kontynuacja po funkcja1");

            client.Close();
            Console.WriteLine("KONIEC Klient1");

            Console.WriteLine("Klient2");

            CallbackHandler callbackHandler = new CallbackHandler();
            InstanceContext context = new InstanceContext(callbackHandler);
            Service2Client client2 = new Service2Client(context);
            double value1 = 10;
            Console.Write(".. wywoluje Silnia({0})", value1);
            client2.Silnia(value1);
            value1 = 20;
            Console.Write(".. wywoluje Silnia({0})", value1);
            client2.Silnia(value1);
            Console.WriteLine("... wyowoluje cosia");
            client2.ObliczCos(2);
            Console.WriteLine(".. czekam na odbior wynikow");
            Thread.Sleep(5000);
            client2.Close();
            Console.WriteLine("Koniec klient 2");
        }
    }
}
