using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StreamContract
{
    [ServiceContract]
    public interface IStreamService
    {
        [OperationContract]
        System.IO.Stream GetStream(String name);
        [OperationContract]
        ResponseFileMessage GetRfmStream(RequestFileMessage request);
    }

    [MessageContract]
    public class RequestFileMessage
    {
        [MessageBodyMember]
        public String name;
    }

    [MessageContract]
    public class ResponseFileMessage
    {
        [MessageHeader]
        public String name;
        [MessageHeader]
        public long size;
        [MessageBodyMember]
        public Stream data;
    }
}
