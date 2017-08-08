using NConcern;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MyServiceTest.Code
{
    public class Logging : IAspect
    {

        public IEnumerable<IAdvice> Advise(MethodBase method)
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
    }

}