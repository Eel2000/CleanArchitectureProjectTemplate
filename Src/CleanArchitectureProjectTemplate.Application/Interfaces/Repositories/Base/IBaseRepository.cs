using System.Linq.Expressions;

namespace CleanArchitectureProjectTemplate.Application.Interfaces.Repositories.Base;

public interface IBaseRepository<TEntity> where TEntity : class
{
    ValueTask<IReadOnlyList<TEntity>> ToListAsync();
    ValueTask<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression);
    ValueTask<IReadOnlyList<TEntity>> ToListAsync(Expression<Func<TEntity, bool>> expression);
    ValueTask<IReadOnlyList<TEntity>> GetPagedResponseAsync(int pageNumber, int pageSize);

    ValueTask<IReadOnlyList<TEntity>> GetPagedResponseAsync(int pageNumber, int pageSize,
        Expression<Func<TEntity, bool>> expression);

    ValueTask<IReadOnlyList<TEntity>> GetPagedResponseV2Async(int pageNumber, int pageSize);
    ValueTask<TEntity> AddAsync(TEntity entity);
    ValueTask<int> AddManyAsync(IEnumerable<TEntity> entities);
    ValueTask<TEntity> UpdateAsync(TEntity entity);
    ValueTask<TEntity> DeleteAsync(TEntity entity);
    ValueTask<TEntity> DeleteAsync(Expression<Func<TEntity, bool>> expression);
}
