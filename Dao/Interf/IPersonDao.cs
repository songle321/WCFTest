using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao.Interf
{
    public interface IPersonDao
    {
        List<Person> List();
        Person Insert(Person entity);
        Person Modify(Person entity);
        Person GetEntityByid(int id);
        bool Modifies(List<Person> persons);
    }
}
