using GradingBlog.Seedwork.Guards;

namespace GradingBlog.DataLayer.Posts;

public sealed class Comment
{
    public Comment(string text, long postId)
    {
        Guard.Against.NullOrWhiteSpace(text, new Exception("لطفا متن کامنت را وارد کنید"));

        Guard.Against.Zero(postId, new Exception("لطفا شناسه پست وارد کنید"));

        Text = text;
        PostId = postId;
    }

    private Comment()
    {
    }

    public long Id { get; set; }

    public string Text { get; }

    public long PostId { get; }

    public Post Post { get; set; }
}