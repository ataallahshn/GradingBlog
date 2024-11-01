using Microsoft.EntityFrameworkCore;

namespace GradingBlog.DataLayer;

public abstract class Repository<TEntity> where TEntity : class
{
    protected readonly DataContext _context;

    protected readonly DbSet<TEntity> dbSet;

    protected Repository(DataContext context)
    {
        _context = context;
        dbSet = context.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity, CancellationToken ct)
    {
        await dbSet.AddAsync(entity, ct);
    }

    public async Task AddRangeAsync(List<TEntity> entity, CancellationToken ct)
    {
        await dbSet.AddRangeAsync(entity, ct);
    }

    public void Update(TEntity entity)
    {
        dbSet.Update(entity);
    }

    public void UpdateRange(List<TEntity> entity, CancellationToken ct)
    {
        dbSet.UpdateRange(entity);
    }
}