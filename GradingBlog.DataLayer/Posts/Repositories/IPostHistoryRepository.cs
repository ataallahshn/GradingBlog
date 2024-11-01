using GradingBlog.DataLayer.Posts.Entities;

namespace GradingBlog.DataLayer.Posts.Repositories;

public interface IPostHistoryRepository
{
    Task AddAsync(PostHistory postHistory, CancellationToken ct);
}