namespace GradingBlog.DataLayer.Posts.Dtos.Request;

public sealed class CreateCommentRequestDto
{
    public long PostId { get; set; }

    public string Text { get; set; }
}