using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Intellectus_mvc
{
    public interface IBaseRepository<T>
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        List<T> Get(Expression<Func<T, bool>> filter);
        T GetById(int id);
        void Insert(T item);
        void Update(T item);
        void Delete(T item);
        void Save(T item);

    }
}
