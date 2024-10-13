using GradingBlog.Seedwork.Entities;

namespace GradingBlog.DataLayer.Posts;

public sealed class PostHistory : Entity<long>
{
    public PostHistory(long postId, string from, string to, DateTime changedOn)
    {
        PostId = postId;
        From = from;
        To = to;
        ChangedOn = changedOn;
    }

    private PostHistory()
    {
    }

    public string From { get; }

    public string To { get; }

    public DateTime ChangedOn { get; }

    public long PostId { get; }

    public Post Post { get; }
}