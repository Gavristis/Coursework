using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Entity.Repositories
{
    public interface IRepository<T>
    {
        void Add(T item);

        void Update(T item);

        void Delete(T item);

        void Delete(long id);

        IEnumerable<T> Get();

        T Get(long id);

        IEnumerable<T> Get(Func<T, bool> predicat);
    }
}
