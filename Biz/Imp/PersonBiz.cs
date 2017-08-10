using Biz.Interf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dao.Interf;

namespace Biz
{
    public class PersonBiz : IPersonBiz
    {
        private IPersonDao _dao;
        public PersonBiz(IPersonDao dao)
        {
            this._dao = dao;
        }
        public Person GetEntityByid(int id)
        {
            return _dao.GetEntityByid(id);
        }

        public Person Insert(Person entity)
        {
            return this._dao.Insert(entity);
        }

        public List<Person> List()
        {
            return this._dao.List();
        }

        public Person Modify(Person entity)
        {
            return this._dao.Modify(entity);
        }
    }
}
