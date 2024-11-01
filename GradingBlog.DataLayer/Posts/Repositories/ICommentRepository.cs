using GradingBlog.DataLayer.Posts.Entities;

namespace GradingBlog.DataLayer.Posts.Repositories;

public interface ICommentRepository
{
    Task AddAsync(Comment comment, CancellationToken ct);
}