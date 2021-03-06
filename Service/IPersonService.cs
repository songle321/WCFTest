﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    [ServiceContract]
    interface IPersonService
    {
        [OperationContract]
        List<Person> List();
        [OperationContract]
        Person Insert(Person entity);
        [OperationContract]
        Person Modify(Person entity);
        [OperationContract]
        Person GetEntityByid(int id);
        [OperationContract]
        bool Modifies(List<Person> ps);


    }
}
