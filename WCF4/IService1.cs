using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF4
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        void Funkcja1(String s1);

        [OperationContract(IsOneWay =true)]
        void Funkcja2(String s2);
    }
}
