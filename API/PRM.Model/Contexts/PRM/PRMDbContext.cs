using Microsoft.EntityFrameworkCore;
using PRM.Core.BaseModel.BaseEntity;
using PRM.Model.Entities;
using System;

namespace PRM.Model.Contexts.PRM
{
    public class PRMDbContext : BaseDbContext, IPRMDbContext
    {
        public PRMDbContext(DbContextOptions<PRMDbContext> options) : base(options)
        {
        }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }

        public DbSet<T> GetDbSet<T>() where T : class, IBaseEntity => Set<T>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Permission>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<PermissionType>().HasQueryFilter(x => !x.Deleted);

            modelBuilder.Entity<PermissionType>().HasData(
                new PermissionType { Id=1, Description = "Enfermedad", CreatedDate = DateTimeOffset.Now},
                new PermissionType { Id = 2,  Description = "Diligencias", CreatedDate = DateTimeOffset.Now },
                new PermissionType { Id = 3,  Description = "Otros", CreatedDate = DateTimeOffset.Now }
                );
        }
    }
}
