using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MyServiceTest.Code
{
    [ServiceContract]
    interface IPersionService
    {
        [OperationContract]
        List<Person> List();
        [OperationContract]
        Person Insert(Person entity);
        [OperationContract]
        Person Modify(Person entity);
        [OperationContract]
        Person GetEntityByid(int id);
    }
}
