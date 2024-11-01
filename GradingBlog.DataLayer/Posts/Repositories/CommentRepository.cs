using GradingBlog.DataLayer.Posts.Entities;

namespace GradingBlog.DataLayer.Posts.Repositories;

public sealed class CommentRepository : Repository<Comment> ,ICommentRepository
{
    public CommentRepository(DataContext context) : base(context)
    {
    }
}