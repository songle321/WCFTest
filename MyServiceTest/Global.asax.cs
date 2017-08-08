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
            var _operationContractJoinpoint = new Func<MethodBase, bool>
                (_Method =>
                {

                    var objType = _Method.DeclaringType;
                    if (objType.FullName != "MyServiceTest.Code.Calculator")
                        return false;
                    var interfaces = objType.GetInterfaces();
                    var flag = false;
                    foreach (Type item in interfaces)
                    {
                        InterfaceMapping map = objType.GetInterfaceMap(item);
                        if (map.TargetMethods == null) continue;
                        var index = Array.IndexOf(map.TargetMethods, _Method);
                        if (index == -1) continue;
                        MethodBase iMethod = map.InterfaceMethods[index];
                        flag = iMethod.IsDefined(typeof(OperationContractAttribute), true);
                        if (flag) break;
                    }
                    if (flag)
                    {
                        Debug.WriteLine("注册" + _Method.DeclaringType + "." + _Method.Name);
                    }
                    return flag;
                }
            );

            //weave logging for all operation contract
            Aspect.Weave<Logging>(_operationContractJoinpoint);
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