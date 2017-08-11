using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Utilitye
{
    public interface IWeaveCondition
    {
       bool Condition(MethodBase method);

    }
}