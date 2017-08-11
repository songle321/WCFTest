using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Biz.Interf;

namespace Service
{
    public class PersonService : IPersonService
    {
        private IPersonBiz _biz;
        public PersonService(IPersonBiz biz)
        {
            this._biz = biz;
        }
        public Person GetEntityByid(int id)
        {
            return this._biz.GetEntityByid(id);
        }

        public Person Insert(Person entity)
        {
            return this._biz.Insert(entity);
        }

        public List<Person> List()
        {
            return this._biz.List();
        }

        public bool Modifies(List<Person> ps)
        {
            return this._biz.TranModify(ps);
        }

        public Person Modify(Person entity)
        {
            return this._biz.Modify(entity);
        }
    }
}
