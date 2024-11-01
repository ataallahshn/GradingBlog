using GradingBlog.DataLayer;
using GradingBlog.DataLayer.Posts.Dtos.Request;
using GradingBlog.Seedwork.Guards;
using GradingBlog.Services.Posts.Services;
using MediatR;

namespace GradingBlog.Services.Posts.Command.UpdatePost;

public sealed class UpdatePostCommandHandler(
    IPostService postService,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdatePostCommand>
{
    public async Task Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var post = await postService.GetPostById(request.PostId, cancellationToken);

        Guard.Against.Null(post, new Exception("شناسه پست معتبر نیست"));

        var createPostHistoryRequestDto = new CreatePostHistoryRequestDto
        {
            PostId = request.PostId,
            From = string.Empty,
            To = string.Empty,
            ChangedOn = DateTime.Now
        };

        await postService.CreatePostHistory(createPostHistoryRequestDto, cancellationToken);

        var updatePostRequestDto = new UpdatePostRequestDto
        {
            PostId = request.PostId,
            Content = request.Content,
            Title = request.Title
        };

        await postService.UpdatePost(updatePostRequestDto, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}