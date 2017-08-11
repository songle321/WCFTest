using Autofac;
using Autofac.Integration.Wcf;
using MyServiceTest.Code;
using NConcern;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Utility;

namespace MyServiceTest
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

            Aspect.Weave<TranCtrl>(TranCtrl.Condition);
            Aspect.Weave<Logging>(Logging.Condition);



            #region container

            var builder = new ContainerBuilder();
            var daoAssembly = Assembly.Load("Dao");
            var bizAssembly = Assembly.Load("Biz");
            var serviceAssemby = Assembly.Load("Service");
            builder.RegisterAssemblyTypes(daoAssembly).Where(t => t.Name.EndsWith("Dao")).AsImplementedInterfaces().AsSelf();
            builder.RegisterAssemblyTypes(bizAssembly).Where(t => t.Name.EndsWith("Biz")).AsImplementedInterfaces().AsSelf();
            builder.RegisterAssemblyTypes(serviceAssemby).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().AsSelf();
            AutofacHostFactory.Container = builder.Build();
            #endregion


        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}