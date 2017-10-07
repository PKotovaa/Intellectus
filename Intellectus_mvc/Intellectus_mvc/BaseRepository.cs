using Intellectus_mvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Intellectus_mvc
{
    public class BaseRepository<T> : IBaseRepository<T>, IDisposable where T : BaseModel
    {
        public IntellectusDbContext context;
        public DbSet<T> dbSet;

        public BaseRepository(IntellectusDbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public BaseRepository() : this(new IntellectusDbContext())
        {
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return dbSet.ToList();
        }

        public List<T> Get(Expression<Func<T, bool>> filter)
        {
            return dbSet.Where(filter).ToList();
        }
        public T GetBy(Expression<Func<T, bool>> filter)
        {
            return dbSet.Where(filter).FirstOrDefault();
        }
        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Insert(T item)
        {
            context.Entry(item).State = EntityState.Added;
            context.SaveChanges();
        }

        public void Update(T item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(T item)
        {
            context.Entry(item).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public virtual void Save(T item)
        {
            if (item.Id == 0)
            {
                Insert(item);
            }
            else
            {
                Update(item);
            }
        }
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~BaseRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}