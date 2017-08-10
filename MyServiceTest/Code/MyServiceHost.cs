using NConcern;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Web;

namespace MyServiceTest.Code
{
    public class MyServiceHost : ServiceHost
    {
        public MyServiceHost(Type serviceType, params Uri[] baseAddresses) : base(serviceType, baseAddresses)
        {

        }
        protected override void OnOpening()
        {
            base.OnOpening();
            Debug.WriteLine("OnOpening");
            var myServiceBehavior = this.Description.Behaviors.Find<MyServiceBehaviorAttribute>();
            if (myServiceBehavior == null)
            {
                myServiceBehavior = new MyServiceBehaviorAttribute();
                this.Description.Behaviors.Add(myServiceBehavior);
            }

            //var _operationContractJoinpoint = new Func<MethodBase, bool>(_Method => _Method.DeclaringType.FullName.StartsWith("MyServiceTest") && _Method.IsDefined(typeof(OperationContractAttribute), true));
            ////weave logging for all operation contract
            //Aspect.Weave<Logging>(_operationContractJoinpoint);
        }
        protected override void OnOpened()
        {
            base.OnOpened();
        }
    }
}