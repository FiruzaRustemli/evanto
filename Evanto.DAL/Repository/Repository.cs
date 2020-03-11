using Evanto.DAL.Context;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace Evanto.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private EvantoContext _dbContext;
        private DbSet<T> _dbSet;
        public Repository(EvantoContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity); 
        }

        public void AddRange(List<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void Delete(int ID)
        {
            var entity = GetById(ID);
            if (entity == null) return;
            else
            {
                Delete(entity);
            }
        }

        public void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = _dbContext.Entry(entity);

            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                _dbSet.Remove(entity);
            }
        }

        public void ExecQuery(string query, params object[] parameters)
        {
            _dbContext.Database.ExecuteSqlCommand(query, parameters);
        }

        //public async Task ExecQueryASync(string query, params object[] parameters)
        //{
        //    await _dbContext.Database.ExecuteSqlCommandAsync(query, parameters);
        //}

        public IEnumerable<T> ExecuteQuery(string query, params object[] parameters)
        {
            var a = _dbContext.Database.SqlQuery<T>(query, parameters);
            return a;
        }

        //public async Task<IList<T>> ExecuteQueryAsync(string query, params object[] parameters)
        //{
        //    return await _dbContext.Database.SqlQuery<T>(query, parameters).ToListAsync();
        //}

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            IQueryable<T> query = null;
            foreach (var include in includes)
            {
                query = _dbSet.Include(include);
            }
            return query.AsExpandable().Where(predicate);
        }
        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AsExpandable().Where(predicate);
        }

        //public async Task<ICollection<T>> GetAllAsync()
        //{
        //    return await _dbSet.ToListAsync();
        //}

        //public async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        //{
        //    return await _dbSet.Where(predicate).ToListAsync();
        //}

        //public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        //{
        //    return await _dbSet.FirstOrDefaultAsync(predicate);
        //}

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        //public async Task<T> GetByIdAsync(int id)
        //{
        //    return await _dbSet.FindAsync(id);
        //}

        public void RemoveRange(List<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public List<T> Test()
        {
            var a = _dbSet;
            return a.ToList();
        }
    }
}
