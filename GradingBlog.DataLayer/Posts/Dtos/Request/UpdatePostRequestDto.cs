namespace GradingBlog.DataLayer.Posts.Dtos.Request;

public sealed class UpdatePostRequestDto
{
    public long PostId { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }
}