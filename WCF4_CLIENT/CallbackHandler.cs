using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF4_CLIENT.ServiceReference2;

namespace WCF4_CLIENT
{
    class CallbackHandler : IService2Callback
    {
        public void ZwrotObliczCos(string result)
        {
            Console.WriteLine(" Obliczenia = {0}", result);
        }

        public void ZwrotSilnia(double result)
        {
            Console.WriteLine("Silnia = {0}", result);
        }
    }
}
