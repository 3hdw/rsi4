using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CallbackContract
{
    public interface ICallbackHandler
    {
        [OperationContract(IsOneWay =true)]
        void ZwrotSilnia(double result);
        [OperationContract(IsOneWay =true)]
        void ZwrotObliczCos(string result); 
    }
}
