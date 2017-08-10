using Dao.Interf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dao.Imp
{
    public class PersonDao : IPersonDao
    {
        private static List<Person> _list = new List<Person>() {
new Person { FirstName="张三",Id=1},
new Person {  FirstName="李四",Id=2}
};
        private static int _id = 2;
        public Person GetEntityByid(int id)
        {
            return _list.FirstOrDefault(p => p.Id == id);
        }

        public Person Insert(Person entity)
        {
            lock (_list)
            {
                _id++;
                entity.Id = _id;
            }
            _list.Add(entity);
            return entity;

        }

        public List<Person> List()
        {
            return _list;
        }

        public Person Modify(Person entity)
        {
            int count = _list.Count;
            var flag = false;
            for (int i = 0; i < count; i++)
            {
                if (_list[i].Id == entity.Id)
                {
                    _list[i] = entity;
                    flag = true;
                }
            }
            if (flag) return entity;
            else return null;
        }

        public bool Modifies(List<Person> persons)
        {
            foreach (var item in persons)
            {
                Modify(item);
            }
            return true;
        }
    }
}
