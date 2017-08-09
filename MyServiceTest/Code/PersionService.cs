using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Biz.Interf;

namespace MyServiceTest.Code
{
    public class PersionService : IPersionService
    {
        private IPersonBiz _biz;
        public PersionService(IPersonBiz biz)
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

        public Person Modify(Person entity)
        {
            return this._biz.Modify(entity);
        }
    }
}
