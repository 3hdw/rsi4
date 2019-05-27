using CallbackContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WCF4;

namespace WCF4_HOST
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8078/WCF4");
            Uri baseAddress2 = new Uri("http://localhost:8079/WCF4");
            ServiceHost myHost = new ServiceHost(typeof(Service1), baseAddress);
            ServiceHost myHost2 = new ServiceHost(typeof(Service2), baseAddress2);
            try
            {
                WSHttpBinding binding = new WSHttpBinding();
                WSDualHttpBinding binding2 = new WSDualHttpBinding();
                myHost.AddServiceEndpoint(typeof(IService1), binding, "endpoint1");
                ServiceEndpoint endpoint2 = myHost2.AddServiceEndpoint(typeof(IService2), binding2, "Callback");
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior
                {
                    HttpGetEnabled = true
                };
                myHost.Description.Behaviors.Add(smb);
                myHost2.Description.Behaviors.Add(smb);
                myHost.Open();
                myHost2.Open();
                Console.WriteLine("Serwis jest uruchomiony.");
                Console.WriteLine("Nacisnij ENTER, aby zakonczyc \n");
                Console.ReadLine();
                myHost.Close();
                myHost2.Close();
                Console.WriteLine("Serwis zamkniety");
            }catch(CommunicationException e)
            {
                Console.WriteLine("Wyjatek: {0}", e.Message);
                myHost.Abort();
                myHost2.Abort();
            }
            Console.ReadLine();
        }
    }
}
