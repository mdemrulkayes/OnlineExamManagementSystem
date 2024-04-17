using System.Linq.Expressions;

namespace SharedKernel.Core;
public interface IRepository<TEntity> : IReadRepository<TEntity>
    where TEntity : BaseEntity
{
    void Add(TEntity entity);
    void Update(TEntity entity);

    void Delete(TEntity entity);
}
