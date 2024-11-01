using GradingBlog.DataLayer.Posts.Dtos.Request;
using GradingBlog.DataLayer.Posts.Dtos.Response;
using GradingBlog.DataLayer.Posts.Entities;

namespace GradingBlog.Services.Posts.Services;

public interface IPostService
{
    Task<long> CreatePost(CreatePostRequestDto createPostRequestDto, CancellationToken ct);

    Task CreatePostHistory(CreatePostHistoryRequestDto createPostHistoryRequestDto, CancellationToken ct);

    Task UpdatePost(UpdatePostRequestDto updatePostRequestDto, CancellationToken ct);

    Task<List<GetPostListResponseDto>> GetPostList(CancellationToken ct);

    Task<Post?> GetPostById(long postId, CancellationToken ct);

    Task<long> CreateComment(CreateCommentRequestDto addCommentRequestDto, CancellationToken ct);
}