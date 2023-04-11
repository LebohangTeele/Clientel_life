using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_API.Repository
{
    public interface IRepository<T1, T2> where T1 : class
    {
        IEnumerable<T1> GetAll();
        IEnumerable<T1> GetbyId(T2 id);
        T1 Insert(T1 entity);
        bool Delete(T2 id);
        T1 Edit(T1 entity);
        bool IfExists(T2 id);

    }
}
