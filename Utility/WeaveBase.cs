using NConcern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Diagnostics;

namespace Utility
{
    public class WeaveBase : IAspect
    {
        public virtual IEnumerable<IAdvice> Advise(MethodBase method)
        {
            return null;
        }
    }
}