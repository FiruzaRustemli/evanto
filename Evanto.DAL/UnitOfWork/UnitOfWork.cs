
using Evanto.DAL.Repository;
using System;
using System.Data.Entity;
using Evanto.DAL.Context;

namespace Evanto.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public EvantoContext EvantoContext;
        
        private DbContextTransaction transaction;
        private static UnitOfWork uow { get; set; }
        private bool _disposed;

        public UnitOfWork()
        {
            EvantoContext = new EvantoContext();
            _disposed = false;            
        }
        //public static UnitOfWork GetInstance()
        //{
        //    if(uow == null)
        //    {
        //        uow = new UnitOfWork();
        //    }
        //    return uow;
        //}
        public void RollBack()
        {
            transaction.Rollback();
        }

        public int SaveChanges()
        {
            return EvantoContext.SaveChanges();
        }
        //public async Task<int> SaveChangesAsync()
        //{
        //    return await _context.SaveChangesAsync();
        //}

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    EvantoContext.Dispose();
                }

                this._disposed = true;
                uow = null; 
            }
        }

        public void BeginTransaction()
        {
            transaction = EvantoContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }
        
        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(EvantoContext);
        }
    }
}
