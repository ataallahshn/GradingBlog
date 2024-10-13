namespace GradingBlog.Application.Posts.Dtos.Request;

public sealed class CreatePostRequestDto
{
    public string Title { get; set; }

    public string Content { get; set; }
}