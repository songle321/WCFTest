using NConcern;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Web;

namespace Utility
{
    public class Logging : WeaveBase
    {

        public override IEnumerable<IAdvice> Advise(MethodBase method)
        {
            yield return Advice.Basic.Around(new Func<object, object[], Func<object>, object>((_Instance, _Arguments, _Body) =>
            {
                Stopwatch watch = new Stopwatch();
                try
                {
                    watch.Start();
                    var _return = _Body();
                    watch.Stop();
                    Debug.WriteLine("耗时：" + watch.Elapsed.Milliseconds + " ms");
                    return _return;
                }
                catch (Exception exception)
                {
                    Debug.WriteLine("发生异常，异常信息：" + exception.Message);
                    throw;
                }
            }));

        }

        public static bool Condition(MethodBase _Method)
        {
            #region LogWeave

            var objType = _Method.DeclaringType;
            var assemblyName = objType.Assembly.GetName();
            if (!assemblyName.Name.StartsWith("MyServiceTest", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            var flag = _Method.IsDefined(typeof(OperationContractAttribute), true);
            if (flag)
                return flag;
            var interfaces = objType.GetInterfaces();
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
            #endregion
        }
    }



    public class TranCtrl : WeaveBase
    {
        public override IEnumerable<IAdvice> Advise(MethodBase method)
        {
            yield return Advice.Basic.Around(new Func<object, object[], Func<object>, object>((_Instance, _Arguments, _Body) =>
            {

                try
                {
                    Debug.WriteLine("Trans Begin");
                    var _return = _Body();
                    Debug.WriteLine("Trans Commit");
                    return _return;
                }
                catch (Exception exception)
                {
                    Debug.WriteLine("Trans RollBack");
                    Debug.WriteLine(exception);
                    throw;
                }
            }));

        }
        public static bool Condition(MethodBase _Method)
        {
            #region LogWeave

            var objType = _Method.DeclaringType;
            var assemblyName = objType.Assembly.GetName();
            var methodName = _Method.Name;
            var flag = assemblyName.Name.Equals("Biz", StringComparison.OrdinalIgnoreCase)
                        && methodName.StartsWith("Tran", StringComparison.OrdinalIgnoreCase);
                        //&& methodName.EndsWith("Biz");
            if (flag)
            {
                Debug.WriteLine("注册" + _Method.DeclaringType + "." + _Method.Name);
            }
            return flag;
            #endregion
        }

    }
}


