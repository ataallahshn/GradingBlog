using GradingBlog.Seedwork.Entities;
using GradingBlog.Seedwork.Guards;

namespace GradingBlog.DataLayer.Posts;

public sealed class Post : Entity<long>
{
    public Post(string title, string content)
    {
        Guard.Against.NullOrWhiteSpace(title, new Exception("لطفا عنوان محتوا وارد"));
        Guard.Against.NullOrWhiteSpace(title, new Exception("لطفا بدنه محتوا وارد"));

        Title = title;
        Content = content;
        ImageId = null;
    }

    private Post()
    {
    }

    public string Title { get; set; }

    public string Content { get; set; }

    public long? ImageId { get; set; }

    public List<Comment> Comments { get; set; }

    public List<PostHistory> PostHistories { get; set; }
}