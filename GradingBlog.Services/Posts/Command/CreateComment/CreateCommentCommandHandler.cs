using GradingBlog.DataLayer;
using GradingBlog.DataLayer.Posts.Dtos.Request;
using GradingBlog.Services.Posts.Services;
using MediatR;

namespace GradingBlog.Services.Posts.Command.CreateComment;

public sealed class CreateCommentCommandHandler(
    IPostService postService,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateCommentCommand, long>
{
    public async Task<long> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var createCommentRequestDto = new CreateCommentRequestDto
        {
            PostId = request.PostId,
            Text = request.Text
        };

        var commentId = await postService.CreateComment(createCommentRequestDto, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return commentId;
    }
}