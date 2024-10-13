using GradingBlog.Seedwork.Guards;

namespace GradingBlog.DataLayer.Posts;

public sealed class Post
{
    public Post(string title, string content)
    {
        Guard.Against.NullOrWhiteSpace(title, new Exception("Title Is Null"));

        Guard.Against.NullOrWhiteSpace(content, new Exception("Content Is Null"));

        Guard.Against.GreaterThan(title.Length, 100, new Exception("max title length is 100"));

        Title = title;
        Content = content;
        ImageId = null;
    }

    private Post()
    {
    }

    public long Id { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public long? ImageId { get; set; }

    public List<Comment> Comments { get; set; }

    public List<PostHistory> PostHistories { get; set; }
}