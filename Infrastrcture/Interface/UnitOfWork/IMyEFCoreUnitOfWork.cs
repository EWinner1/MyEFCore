using Microsoft.EntityFrameworkCore.Storage;
using MyEFCore.Infrastrcture.Interface.Repositories;

namespace MyEFCore.Infrastrcture.Interface.UnitOfWork
{
    public interface IMyEFCoreUnitOfWork
    {
        void DetectChanges();
        int SaveChanges();
        Task SaveChangesAsync();
        void RejectChanges();
        void Attach(object entity);
        void SetUnchanged(object entity);
        void SetDetached(object entity);
        IDbContextTransaction BeginTransaction();
    }
}
