using StreamContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace StreamHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8082/Stream");
            ServiceHost myHost = new ServiceHost(typeof(StreamService), baseAddress);
            try
            {
                BasicHttpBinding binding = new BasicHttpBinding
                {
                    TransferMode = TransferMode.Streamed,
                    MaxReceivedMessageSize = 1000000000,
                    MaxBufferSize = 8192
                };
                ServiceEndpoint endpoint = myHost.AddServiceEndpoint(typeof(IStreamService), binding, "endpoint1");
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior
                {
                    HttpGetEnabled = true
                };
                myHost.Description.Behaviors.Add(smb);
                myHost.Open();
                Console.WriteLine("Serwis jest uruchomiony.");
                Console.WriteLine("Nacisnij ENTER, aby zakonczyc \n");
                Console.ReadLine();
                myHost.Close();
                Console.WriteLine("Serwis zamkniety");
            }
            catch (CommunicationException e)
            {
                Console.WriteLine("Wyjatek: {0}", e.Message);
                myHost.Abort();
            }
            Console.ReadLine();
        }
    }
}
