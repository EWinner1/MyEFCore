using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using MyEFCore.Infrastrcture.Interface.UnitOfWork;

namespace MyEFCore.UnitOfWork
{
    public class MyEFCoreUnitOfWork<TDbContext> : IMyEFCoreUnitOfWork where TDbContext : DbContext
    {
        protected readonly TDbContext Context;
        protected readonly IDbContextTransaction dbContextTransaction;
        public MyEFCoreUnitOfWork(TDbContext context) => this.Context = context;

        public virtual void Attach(object entity) => this.Context.Attach(entity);

        public virtual void AutoDetectChangesDisabled() => this.Context.ChangeTracker.AutoDetectChangesEnabled = false;

        public IDbContextTransaction BeginTransaction() => this.Context.Database.BeginTransaction();

        public virtual async Task<IDbContextTransaction> BeginTransactionAsync() => await this.Context.Database.BeginTransactionAsync();

        public virtual void DetectChanges() => this.Context.ChangeTracker.DetectChanges();

        public virtual int SaveChanges() => this.Context.SaveChanges();

        public virtual async Task SaveChangesAsync() => await this.Context.SaveChangesAsync();

        public virtual void SetDetached(object entity) => this.Context.Entry(entity).State = EntityState.Detached;

        public virtual void SetUnchanged(object entity) => this.Context.Entry(entity).State = EntityState.Unchanged;

        public virtual void SetDeleted(object entity) => this.Context.Entry(entity).State = EntityState.Deleted;

        public virtual void RejectChanges()
        {
            var Enumerator = this.Context.ChangeTracker.Entries().GetEnumerator();
            while (Enumerator.MoveNext())
            {
                switch (Enumerator.Current.State)
                {
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        Enumerator.Current.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        Enumerator.Current.State = EntityState.Detached;
                        break;
                }
            }
        }
    }
}
