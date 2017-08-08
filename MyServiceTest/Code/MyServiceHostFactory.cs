﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web;

namespace MyServiceTest.Code
{
    public class MyServiceHostFactory : ServiceHostFactory
    {
        //MyServiceHost
        // SVC中的constructorString， Service="MyServiceTest.Service1"
        //该方法主要是再svc中用于传递一下参数可以解析，作为
        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            return base.CreateServiceHost(constructorString, baseAddresses);
        }

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new MyServiceHost(serviceType, baseAddresses);
        }
    }
}