using Microsoft.EntityFrameworkCore;
using PRM.Core.BaseModel.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PRM.Model.Contexts
{
    public abstract class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions options) : base(options)
        {
            
        }

        private void SetAuditEntities()
        {
            foreach (var entry in ChangeTracker.Entries<IBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:

                        if (entry.Entity.Id > 0)
                        {
                            entry.State = EntityState.Modified;
                            goto case EntityState.Modified;
                        }

                        entry.Entity.Deleted = false;
                        if (!entry.Entity.CreatedDate.HasValue)
                            entry.Entity.CreatedDate = DateTimeOffset.Now;
                        break;
                    case EntityState.Modified:
                        entry.Property(x => x.CreatedDate).IsModified = false;
                        entry.Entity.UpdatedDate = DateTimeOffset.Now;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.Deleted = true;
                        goto case EntityState.Modified;

                    default:
                        goto case EntityState.Modified;
                }
            }
        }
        public override int SaveChanges()
        {
            SetAuditEntities();
            return base.SaveChanges();
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            SetAuditEntities();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetAuditEntities();
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
