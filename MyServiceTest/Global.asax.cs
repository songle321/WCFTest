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

namespace MyServiceTest
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            #region LogWeave
            //var _operationContractJoinpoint = new Func<MethodBase, bool>
            //       (_Method =>
            //       {
            //           var objType = _Method.DeclaringType;
            //           var assemblyName = objType.Assembly.GetName();
            //           if (!assemblyName.Name.StartsWith("MyServiceTest", StringComparison.OrdinalIgnoreCase))
            //           {
            //               return false;
            //           }
            //           var flag = _Method.IsDefined(typeof(OperationContractAttribute), true);
            //           if (flag)
            //               return flag;
            //           var interfaces = objType.GetInterfaces();
            //           foreach (Type item in interfaces)
            //           {
            //               InterfaceMapping map = objType.GetInterfaceMap(item);
            //               if (map.TargetMethods == null) continue;
            //               var index = Array.IndexOf(map.TargetMethods, _Method);
            //               if (index == -1) continue;
            //               MethodBase iMethod = map.InterfaceMethods[index];
            //               flag = iMethod.IsDefined(typeof(OperationContractAttribute), true);
            //               if (flag) break;
            //           }
            //           if (flag)
            //           {
            //               Debug.WriteLine("注册" + _Method.DeclaringType + "." + _Method.Name);
            //           }
            //           return flag;
            //       }
            //   );
            ////weave logging for all operation contract
            //Aspect.Weave<Logging>(_operationContractJoinpoint);
            #endregion
            Aspect.Weave<Logging>(Logging.Condition);
            Aspect.Weave<TranCtrl>(TranCtrl.Condition);

            //  WeaveFactory.Weave<Logging>();
            // WeaveFactory.Weave<TranCtrl>();
            #region container

            var builder = new ContainerBuilder();
            var daoAssembly = Assembly.Load("Dao");
            var bizAssembly = Assembly.Load("Biz");
            var serviceAssemby = Assembly.Load("MyServiceTest");
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