using GradingBlog.DataLayer.Posts.Dtos.Response;
using MediatR;

namespace GradingBlog.Services.Posts.Query.GetPostListQuery;

public sealed record GetPostListQuery : IRequest<List<GetPostListResponseDto>>;