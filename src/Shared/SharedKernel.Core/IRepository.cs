using System.Linq.Expressions;

namespace SharedKernel.Core;
public interface IRepository<TEntity> : IReadRepository<TEntity>
    where TEntity : BaseEntity
{
    TEntity Add(TEntity entity);
    TEntity Update(TEntity entity);

    TEntity Delete(TEntity entity);
}
