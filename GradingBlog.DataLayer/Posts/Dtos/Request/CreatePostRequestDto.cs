namespace GradingBlog.DataLayer.Posts.Dtos.Request;

public sealed class CreatePostRequestDto
{
    public string Title { get; set; }

    public string Content { get; set; }
}