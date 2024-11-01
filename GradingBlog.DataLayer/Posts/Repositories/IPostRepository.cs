using GradingBlog.DataLayer.Posts.Dtos.Response;
using GradingBlog.DataLayer.Posts.Entities;

namespace GradingBlog.DataLayer.Posts.Repositories;

public interface IPostRepository
{
    Task AddAsync(Post post, CancellationToken ct);

    void Update(Post post);

    Task<List<GetPostListResponseDto>> GetList(CancellationToken ct);

    Task<Post?> GetById(long postId, CancellationToken ct);
}