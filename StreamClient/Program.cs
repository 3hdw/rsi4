using StreamClient.StreamServiceReference;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamClient
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamServiceClient client = new StreamServiceClient();
            String filePath = Path.Combine(System.Environment.CurrentDirectory, "klient.jpg");
            Console.WriteLine("Wywoluje getStream()");
            Stream stream = client.GetStream("image.jpg");
            saveFile(stream, filePath);

            //####

            Console.WriteLine("Wywoluje getRfmStream()");
            long size;
            String name = "image.jpg";
            size = client.GetRfmStream(ref name, out Stream fis);
            Console.WriteLine(size);
            String filePathRfm = Path.Combine(System.Environment.CurrentDirectory, "klientRfm.jpg");
            saveFile(fis, filePathRfm);

            client.Close();

        }

        private static void saveFile(Stream fis, string filePath)
        {
            int bufferLength = 8192;
            int byteCount = 0;
            int counter = 0;
            byte[] buffer = new byte[bufferLength];
            Console.WriteLine("Zapisuje plik -> {0}", filePath);
            FileStream fos = File.Open(filePath, FileMode.Create, FileAccess.Write);
            while ((counter = fis.Read(buffer, 0, bufferLength))>0)
            {
                fos.Write(buffer, 0, counter);
                Console.Write(".{0}", counter);
                byteCount += counter;
            }
            Console.WriteLine("\n Plik zapisany -> {0}", filePath);
        }
    }
}
