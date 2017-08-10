using NConcern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Utility
{
    public class WeaveFactory
    {
        public static void Weave<T>() where T : class, IAspect, new()
        {
            var type = typeof(T);
            var mm = type.GetMethod("Condition", BindingFlags.Static);
            Func<MethodBase, bool> func = m =>
            {
                return (bool)mm.Invoke(null, new object[] { m });
            };
            Aspect.Weave<T>(func);

        }
    }
}