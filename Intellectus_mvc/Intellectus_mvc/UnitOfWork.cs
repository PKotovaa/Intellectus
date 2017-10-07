using Intellectus_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intellectus_mvc
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IntellectusDbContext context;
        Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public UnitOfWork(IntellectusDbContext context)
        {
            if (context == null)
                throw new ArgumentException(nameof(context));
            this.context = context;

        }

        public IBaseRepository<T> GetRepository<T>() where T : BaseModel
        {
            if (!repositories.ContainsKey(typeof(T)))
            {
                repositories.Add(typeof(T), new BaseRepository<T>(context));
            }
            return (IBaseRepository<T>)repositories[typeof(T)];
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                context.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}