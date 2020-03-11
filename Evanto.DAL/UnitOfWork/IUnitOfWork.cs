using Evanto.DAL.Context;
using Evanto.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : class;
        void BeginTransaction();
        int SaveChanges();
        //Task<int> SaveChangesAsync();
        void RollBack();
        void Commit();
        void Dispose();
    }
}
