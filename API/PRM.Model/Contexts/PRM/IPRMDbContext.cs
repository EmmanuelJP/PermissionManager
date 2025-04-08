using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PRM.Core.BaseModel.BaseEntity;
using PRM.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PRM.Model.Contexts.PRM
{
    public interface IPRMDbContext : IDisposable
    {
        DatabaseFacade Database { get; }
        DbSet<T> GetDbSet<T>() where T : class, IBaseEntity;
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        EntityEntry<T> Entry<T>(T entity) where T : class;

        DbSet<Permission> Permissions { get; set; }
        DbSet<PermissionType> PermissionTypes { get; set; }
    }
}
