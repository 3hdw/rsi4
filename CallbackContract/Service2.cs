using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace CallbackContract
{
    [ServiceBehavior(InstanceContextMode =InstanceContextMode.PerSession)]
    public class Service2 : IService2
    {
        double result;
        ICallbackHandler callback = null;

        public Service2()
        {
            callback = OperationContext.Current.GetCallbackChannel<ICallbackHandler>();
        }

        public void ObliczCos(int sek)
        {
            Console.WriteLine("... Wywolano ObliczCos({0})", sek);
            if (sek < 10)
                Thread.Sleep(1000 * sek);
            else
                Thread.Sleep(1000);
            callback.ZwrotObliczCos("Obliczenia trwaly " + (sek + 1) + " sekundy");
        }

        public void Silnia(double n)
        {
            Console.WriteLine("... wyolano Silnia({0})", n);
            Thread.Sleep(1000);
            result = 1;
            for (int i = 2; i <= n; i++)
                result *= i;
            callback.ZwrotSilnia(result);
        }
    }
}
