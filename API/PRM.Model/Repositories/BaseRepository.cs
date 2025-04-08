using Microsoft.EntityFrameworkCore;
using PRM.Core.BaseModel.BaseEntity;
using PRM.Model.Contexts.PRM;
using PRM.Model.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PRM.Model.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity
    {
        public readonly IUnitOfWork<IPRMDbContext> _uow;
        public readonly IPRMDbContext _context;
        public readonly DbSet<T> _dbSet;

        public BaseRepository(IUnitOfWork<IPRMDbContext> uow)
        {
            _uow = uow;
            _context = _uow.Context;
            _dbSet = _context.GetDbSet<T>();
        }
        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = AsQueryable();

            foreach (var property in includeProperties)
                query = query.Include(property);

            if (predicate is null)
                return query;

            return query.Where(predicate);
        }
        public virtual T First(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties) => GetAll(predicate, includeProperties).FirstOrDefault();

        public virtual T GetById(int id, params Expression<Func<T, object>>[] includeProperties) => First(x => x.Id == id);
        public virtual T Add(T entity)
        {
           return _dbSet.Add(entity).Entity;
        }
        public virtual void Add(params T[] entities)
        {
            _dbSet.AddRange(entities);
        }
        public virtual void Add(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }
       
        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
        public virtual void Delete(int id)
        {
            T entity = GetById(id);
            _dbSet.Remove(entity);
        }
        public virtual void Delete(params T[] entities)
        {
            _dbSet.RemoveRange(entities);
        }
        public virtual void Delete(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
        public virtual T Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
        public virtual void Update(params T[] entities)
        {
            foreach (T entity in entities)
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
        }
        public virtual void Update(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
        }

        public void Dispose()
        {
            _uow.Dispose();
        }
       
        public IQueryable<T> AsQueryable()
        {
            return _dbSet.AsQueryable();
        }
    }
}
