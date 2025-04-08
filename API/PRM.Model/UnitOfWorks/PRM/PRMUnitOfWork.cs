using PRM.Core.BaseModel.BaseEntity;
using PRM.Model.Contexts.PRM;
using PRM.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PRM.Model.UnitOfWorks.PRM
{
    public class PRMUnitOfWork : IUnitOfWork<IPRMDbContext>
    {
        public IPRMDbContext Context { get; set; }

        private readonly IServiceProvider _serviceProvider;

        public PRMUnitOfWork(IServiceProvider serviceProvider, IPRMDbContext context)
        {
            _serviceProvider = serviceProvider;
            this.Context = context;
        }

        public async Task<int> Commit()
        {
            var result = await Context.SaveChangesAsync();
            return result;
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IBaseEntity
        {
            return (_serviceProvider.GetService(typeof(TEntity)) ?? new BaseRepository<TEntity>(this)) as IBaseRepository<TEntity>;
        }
    }
}
