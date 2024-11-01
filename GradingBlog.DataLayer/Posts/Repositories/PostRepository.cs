using GradingBlog.DataLayer.Posts.Dtos.Response;
using GradingBlog.DataLayer.Posts.Entities;
using Microsoft.EntityFrameworkCore;

namespace GradingBlog.DataLayer.Posts.Repositories;

public sealed class PostRepository : Repository<Post>, IPostRepository
{
    public PostRepository(DataContext context) : base(context)
    {
    }

    public async Task<List<GetPostListResponseDto>> GetList(CancellationToken ct)
    {
        var posts = await dbSet
            .AsNoTracking()
            .Select(post => new GetPostListResponseDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                Comments = post.Comments.Select(comment => new GetPostListCommentResponseDto
                {
                    Id = comment.Id,
                    Text = comment.Text
                }).ToList()
            })
            .ToListAsync(ct);

        return posts;
    }

    public async Task<Post?> GetById(long postId, CancellationToken ct)
    {
        return await dbSet
            .AsNoTracking()
            .SingleOrDefaultAsync(post => post.Id == postId, ct);
    }
}