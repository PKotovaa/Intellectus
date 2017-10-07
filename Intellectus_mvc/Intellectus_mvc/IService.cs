using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Intellectus_mvc
{
    public interface IService<T>
    {
        T Get(int id);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        void Update(T item);
        void Delete(T item);
    }
}
