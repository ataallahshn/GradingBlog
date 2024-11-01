namespace GradingBlog.DataLayer;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken ct);

    Task BeginTransactionAsync(CancellationToken ct);

    Task CommitTransactionAsync(CancellationToken ct);

    Task RollbackTransactionAsync(CancellationToken ct);
}