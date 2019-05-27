using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StreamContract
{
    public class StreamService : IStreamService
    {
        public ResponseFileMessage GetRfmStream(RequestFileMessage request)
        {
            ResponseFileMessage responseFileMessage = new ResponseFileMessage();
            String name = request.name;
            FileStream file;
            Console.WriteLine("Wywolano GetRfmStream(Request:{0})", name);
            String filePath = Path.Combine(System.Environment.CurrentDirectory, name);
            try
            {
                file = File.OpenRead(filePath);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
            responseFileMessage.name = name;
            responseFileMessage.size = file.Length;
            responseFileMessage.data = file;
            return responseFileMessage;
        }

        public Stream GetStream(string name)
        {
            FileStream file;
            Console.WriteLine("Wywolano getStream({0})", name);
            String filePath = Path.Combine(System.Environment.CurrentDirectory, name);
            try
            {
                file = File.OpenRead(filePath);
            }catch(IOException e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
            return file;
        }
    }
}
