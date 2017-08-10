using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Web;

namespace MyServiceTest.Code
{
    public class ErrorOperationBehaviorAttribute : Attribute, IOperationBehavior
    {
        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {

        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {

        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            Type type = null;
            if (operationDescription.SyncMethod != null)
            {
                type = operationDescription.SyncMethod.ReturnType;
            }
            dispatchOperation.Invoker = new MyOperationInvoker(dispatchOperation.Invoker, dispatchOperation, type);

        }

        public void Validate(OperationDescription operationDescription)
        {

        }
    }
}