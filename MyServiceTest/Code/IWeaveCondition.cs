﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MyServiceTest.Code
{
    public interface IWeaveCondition
    {
       bool Condition(MethodBase method);

    }
}