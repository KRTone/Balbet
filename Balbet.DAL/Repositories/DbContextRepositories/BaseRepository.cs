using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Balbet.DAL.Interfaces;

namespace Balbet.DAL.Repositories.DbContextRepositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        public DbContext.DbContext DataContext { get; private set; }

        public BaseRepository(DbContext.DbContext context)
        {
            this.DataContext = context;
            this.disposedValue = false;
        }

        public abstract T Add(T entity);
        public abstract void Delete(string entity);
        public abstract IQueryable<T> Get();
        public abstract T Get(string entityId);
        public abstract T Update(T entity);
        public abstract IQueryable<T> Paging(int skip, int take);

        #region Dispose supporting
        private bool disposedValue; // To detect redundant calls
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    DataContext.Dispose();
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
