using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class BaseDao<T> where T : class
    {
        public virtual bool InsertEntity(T obj)
        {
            return true;
        }
    }
}
