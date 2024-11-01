namespace GradingBlog.DataLayer;

public sealed class UnitOfWork(DataContext context) : IUnitOfWork
{
    public async Task SaveChangesAsync(CancellationToken ct)
    {
        await context.SaveChangesAsync(ct);
    }

    public async Task BeginTransactionAsync(CancellationToken ct)
    {
        if (context.Database.CurrentTransaction is null)
        {
            await context.Database.BeginTransactionAsync(ct);
        }
    }

    public async Task CommitTransactionAsync(CancellationToken ct)
    {
        if (context.Database.CurrentTransaction is null)
        {
            throw new Exception("");
        }

        await context.Database.CommitTransactionAsync(ct);
    }

    public async Task RollbackTransactionAsync(CancellationToken ct)
    {
        if (context.Database.CurrentTransaction is null)
        {
            throw new Exception("");
        }

        await context.Database.RollbackTransactionAsync(ct);
    }
}