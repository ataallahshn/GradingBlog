using GradingBlog.Application.Posts.Dtos.Request;
using GradingBlog.Application.Posts.Dtos.Response;

namespace GradingBlog.Application.Posts.Services;

public interface IPostService
{
    Task<long> CreatePost(CreatePostRequestDto createPostRequestDto, CancellationToken ct);

    Task UpdatePost(UpdatePostRequestDto updatePostRequestDto, CancellationToken ct);

    Task<List<GetPostListResponseDto>> GetPostList(CancellationToken ct);

    Task<long> CreateComment(CreateCommentRequestDto addCommentRequestDto, CancellationToken ct);
}