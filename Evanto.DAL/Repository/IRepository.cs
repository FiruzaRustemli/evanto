using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Evanto.DAL.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        //Task<ICollection<T>> GetAllAsync();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, params string[] includes);
        //Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        T GetById(int id);
        //Task<T> GetByIdAsync(int id);
        T Get(Expression<Func<T, bool>> predicate);
        //Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int Id);

        IEnumerable<T> ExecuteQuery(string query, params object[] parameters);
        //Task<IList<T>> ExecuteQueryAsync(string query, params object[] parameters);
        void ExecQuery(string query, params object[] parameters);
        //Task ExecQueryASync(string query, params object[] parameters);

        void AddRange(List<T> entities);
        void RemoveRange(List<T> entities);

        List<T> Test();
    }
}
