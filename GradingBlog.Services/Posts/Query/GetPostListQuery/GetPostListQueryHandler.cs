using GradingBlog.DataLayer.Posts.Dtos.Response;
using GradingBlog.Services.Posts.Services;
using MediatR;

namespace GradingBlog.Services.Posts.Query.GetPostListQuery;

public sealed class GetPostListQueryHandler(IPostService postService)
    : IRequestHandler<GetPostListQuery, List<GetPostListResponseDto>>
{
    public async Task<List<GetPostListResponseDto>> Handle(
        GetPostListQuery request,
        CancellationToken cancellationToken)
    {
        return await postService.GetPostList(cancellationToken);
    }
}