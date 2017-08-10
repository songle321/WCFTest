using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biz.Interf
{
    public interface IPersonBiz
    {
        List<Person> List();
        Person Insert(Person entity);
        Person Modify(Person entity);
        Person GetEntityByid(int id);

        bool TranModify(List<Person> persons);
    }
}
