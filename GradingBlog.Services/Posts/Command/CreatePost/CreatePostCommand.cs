using MediatR;

namespace GradingBlog.Services.Posts.Command.CreatePost;

public sealed record CreatePostCommand(string Title, string Content) : IRequest<long>;