using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Dispatcher;
using System.Web;

namespace MyServiceTest.Code
{
    public class MyOperationInvoker : IOperationInvoker
    {
        private IOperationInvoker invoker;

        private readonly Type returnType;

        private string operationName;

        public MyOperationInvoker(IOperationInvoker baseInvoker, DispatchOperation operation, Type returnType)
        {
            this.invoker = baseInvoker;
            this.operationName = operation.Name;
            this.returnType = returnType;
        }

        public object[] AllocateInputs()
        {
            return this.invoker.AllocateInputs();
        }

        private void InvokeBefore(object instance, object[] inputs)
        {

        }

        private void InvokeAfter(object instance, object[] inputs, object[] outputs)
        {

        }

        //private object InvokeExceptionDeal(object instance, object[] inputs)
        //{
        //    //return "123";
        //    //var returnType = (Inner as System.ServiceModel.Dispatcher.sy).Method.ReturnType;
        //    if (returnType != null)
        //    {
        //        object o = returnType.Assembly.CreateInstance(returnType.FullName);
        //        DTOResult dto = o as DTOResult;
        //        if (dto != null)
        //        {
        //            dto.Code = (int)BCMResposeCode.SYSTEM_ERROR;
        //        }
        //        return dto;
        //    }
        //    return null;
        //}

        public object Invoke(object instance, object[] inputs, out object[] outputs)
        {
            InvokeBefore(instance, inputs);
            object result = null;
            try
            {
                result = this.invoker.Invoke(instance, inputs, out outputs);

            }
            catch (Exception exception)
            {
                outputs = new object[0];
                //result = InvokeExceptionDeal(instance, inputs);
                Debug.WriteLine("异常错误", exception);
            }
            InvokeAfter(instance, inputs, outputs);

            return result;
        }

        public IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state)
        {
            throw new Exception("不支持异步");

        }

        public object InvokeEnd(object instance, out object[] outputs, IAsyncResult result)
        {
            throw new Exception("不支持异步");
        }

        public bool IsSynchronous
        {
            get
            {
                return true;
            }
        }
    }
}