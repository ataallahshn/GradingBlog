using GradingBlog.DataLayer.Posts.Entities;

namespace GradingBlog.DataLayer.Posts.Repositories;

public sealed class PostHistoryRepository : Repository<PostHistory>, IPostHistoryRepository
{
    public PostHistoryRepository(DataContext context) : base(context)
    {
    }
}