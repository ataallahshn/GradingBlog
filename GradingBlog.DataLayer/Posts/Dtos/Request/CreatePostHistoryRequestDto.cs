namespace GradingBlog.DataLayer.Posts.Dtos.Request;

public sealed class CreatePostHistoryRequestDto
{
    public long PostId { get; set; }

    public string From { get; set; }

    public string To { get; set; }

    public DateTime ChangedOn { get; set; }
}