using CleanArchitectureProjectTemplate.Application.Interfaces.Repositories.Base;
using CleanArchitectureProjectTemplate.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CleanArchitectureProjectTemplate.Persistence.Repositories.Base;

internal class BaseRepository<TEntity>(ApplicationDataContext context) : IBaseRepository<TEntity> where TEntity : class
{
    public async ValueTask<IReadOnlyList<TEntity>> GetPagedResponseAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> expression)
    {
        var data = await context
            .Set<TEntity>()
            .AsNoTracking()
            .Where(expression)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return data;
    }

    public async ValueTask<IReadOnlyList<TEntity>> GetPagedResponseV2Async(int pageNumber, int pageSize)
    {
        var data = context
            .Set<TEntity>()
            .AsEnumerable()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        await Task.Delay(500);
        return data;
    }

    public async ValueTask<TEntity> AddAsync(TEntity entity)
    {
        await context.Set<TEntity>().AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async ValueTask<TEntity> DeleteAsync(TEntity entity)
    {
        var entry = context.Set<TEntity>().Remove(entity);
        await context.SaveChangesAsync();

        return entry.Entity;
    }

    public async ValueTask<TEntity> DeleteAsync(Expression<Func<TEntity, bool>> expression)
    {
        var delEntity = await context.Set<TEntity>().FirstOrDefaultAsync(expression);

        if (delEntity is null) throw new ApplicationException("Information or Entity entry not found");

        var entry = context.Set<TEntity>().Remove(delEntity);
        await context.SaveChangesAsync();

        return entry.Entity;
    }

    public async ValueTask<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
        => await context.Set<TEntity>().FirstOrDefaultAsync(expression);

    public async ValueTask<IReadOnlyList<TEntity>> ToListAsync()
        => await context.Set<TEntity>().ToListAsync();

    public async ValueTask<IReadOnlyList<TEntity>> ToListAsync(Expression<Func<TEntity, bool>> expression)
        => await context.Set<TEntity>().Where(expression).ToListAsync();

    public async ValueTask<IReadOnlyList<TEntity>> GetPagedResponseAsync(int pageNumber, int pageSize)
    {
        var data = await context
            .Set<TEntity>()
            .AsNoTracking()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return data;
    }

    public async ValueTask<TEntity> UpdateAsync(TEntity entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return entity;
    }

    public async ValueTask<int> AddManyAsync(IEnumerable<TEntity> entities)
    {
        await context.Set<TEntity>().AddRangeAsync(entities);
        await context.SaveChangesAsync();
        return entities.Count();
    }
}
