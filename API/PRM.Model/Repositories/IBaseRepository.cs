using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PRM.Model.Repositories
{
    public interface IBaseRepository<T> : IDisposable where T : class
    {
        IQueryable<T> AsQueryable();

        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);

        T First(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        T GetById(int id, params Expression<Func<T, object>>[] includeProperties);

        T Add(T entity);
        void Add(params T[] entities);
        void Add(IEnumerable<T> entities);

        void Delete(T entity);
        void Delete(int id);
        void Delete(params T[] entities);
        void Delete(IEnumerable<T> entities);

        T Update(T entity);
        void Update(params T[] entities);
        void Update(IEnumerable<T> entities);
    }
}
