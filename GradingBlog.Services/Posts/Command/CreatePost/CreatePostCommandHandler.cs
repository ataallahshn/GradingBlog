using GradingBlog.DataLayer;
using GradingBlog.DataLayer.Posts.Dtos.Request;
using GradingBlog.Services.Posts.Services;
using MediatR;

namespace GradingBlog.Services.Posts.Command.CreatePost;

public sealed class CreatePostCommandHandler(
    IPostService postService,
    IUnitOfWork unitOfWork) : IRequestHandler<CreatePostCommand, long>
{
    public async Task<long> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var createPostRequestDto = new CreatePostRequestDto
        {
            Title = request.Title,
            Content = request.Content
        };

        var postId = await postService.CreatePost(createPostRequestDto, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return postId;
    }
}