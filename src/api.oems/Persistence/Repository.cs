using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using api.oems.Core;
using Microsoft.EntityFrameworkCore;

namespace api.oems.Persistence
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly OemsDbContext _dbContext;

        public Repository(OemsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(T entity)
        {
           _dbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(predicate);
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).Count();
        }
    }
}
