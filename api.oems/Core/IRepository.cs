using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.oems.Core
{
    public interface IRepository<T> where T: class 
    {
        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);

        Task<T> FindAsync(Expression<Func<T, bool>> predicate);

        int Count(Expression<Func<T, bool>> predicate);
    }
}
