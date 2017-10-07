using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intellectus_mvc
{
    interface IUnitOfWork
    {
        int Save();
        void Dispose();
    }
}
