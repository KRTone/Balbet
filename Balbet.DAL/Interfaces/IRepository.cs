using System;
using System.Linq;

namespace Balbet.DAL.Interfaces
{
    public interface IRepository<T> : IRepository where T : class
    {
        T Add(T entity);
        void Delete(string entity);
        T Update(T entity);
        T Get(string entityId);
        IQueryable<T> Get();
        IQueryable<T> Paging(int skip, int take);
    }

    public interface IRepository : IDisposable
    {
    }
}
