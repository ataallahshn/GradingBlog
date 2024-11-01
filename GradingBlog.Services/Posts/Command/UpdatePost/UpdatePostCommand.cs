using MediatR;

namespace GradingBlog.Services.Posts.Command.UpdatePost;

public sealed record UpdatePostCommand(long PostId, string Title, string Content) : IRequest;