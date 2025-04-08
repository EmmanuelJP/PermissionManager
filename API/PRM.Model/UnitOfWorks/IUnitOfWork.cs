using PRM.Core.BaseModel.BaseEntity;
using PRM.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PRM.Model.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IBaseEntity;
        Task<int> Commit();
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork
    {
        TContext Context { get; }
    }
}
