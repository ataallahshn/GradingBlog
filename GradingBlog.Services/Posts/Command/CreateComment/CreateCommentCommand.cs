using MediatR;

namespace GradingBlog.Services.Posts.Command.CreateComment;

public sealed record CreateCommentCommand(long PostId, string Text) : IRequest<long>;