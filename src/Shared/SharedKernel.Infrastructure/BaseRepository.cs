﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Core;
using SharedKernel.Core.Extensions;

namespace SharedKernel.Infrastructure;
public class BaseRepository<TEntity>(DbContext context) : IRepository<TEntity>
    where TEntity : BaseEntity
{
    public virtual void Add(TEntity entity)
    {
        context.Set<TEntity>().Add(entity);
    }

    public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await context.Set<TEntity>().AnyAsync(expression);
    }

    public virtual void Delete(TEntity entity)
    {
        context.Set<TEntity>().Remove(entity);
    }

    public virtual async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null, CancellationToken cancellationToken = default)
    {
        if (expression != null)
            return await context.Set<TEntity>().Where(expression)
                .ToListAsync(cancellationToken);
        return await context.Set<TEntity>()
            .ToListAsync(cancellationToken);
    }

    public virtual async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression, string includeProperties = "")
    {
        return await context.Set<TEntity>().FirstOrDefaultAsync(expression);
    }

    public virtual async Task<PaginatedList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null, int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        if (expression != null)
            return await context.Set<TEntity>().Where(expression)
                .ToPaginatedListAsync(pageNumber, pageSize, cancellationToken);
        return await context.Set<TEntity>()
            .ToPaginatedListAsync(pageNumber, pageSize, cancellationToken);
    }

    public virtual void Update(TEntity entity)
    {
        context.Set<TEntity>().Update(entity);
    }
}
