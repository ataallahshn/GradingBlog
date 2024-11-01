namespace GradingBlog.DataLayer.Posts.Dtos.Response;

public sealed class GetPostListResponseDto
{
    public long Id { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public List<GetPostListCommentResponseDto> Comments { get; set; }
}

public sealed class GetPostListCommentResponseDto
{
    public long Id { get; set; }

    public string Text { get; set; }
}