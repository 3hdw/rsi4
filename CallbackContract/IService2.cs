using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CallbackContract
{
    [ServiceContract(SessionMode = SessionMode.Required,
        CallbackContract = typeof(ICallbackHandler))]
    public interface IService2
    {
        [OperationContract(IsOneWay = true)]
        void Silnia(double n);

        [OperationContract(IsOneWay = true)]
        void ObliczCos(int sek);
    }
}
