using GradingBlog.DataLayer.Posts;
using GradingBlog.DataLayer.Posts.Entities;

namespace GradingBlog.UnitTest.Posts;

public class PostUnitTest
{
    [Fact]
    public void Post_ShouldThrowException_WhenTitleIsNullOrWhiteSpace()
    {
        var title = "";
        var content = "Hello World";

        var exception = Assert.Throws<Exception>(() => new Post(title, content));

        Assert.Equal("Title Is Null", exception.Message);
    }

    [Fact]
    public void Post_ShouldThrowException_WhenContentIsNullOrWhiteSpace()
    {
        var title = "Hello World";
        var content = "";

        var exception = Assert.Throws<Exception>(() => new Post(title, content));

        Assert.Equal("Content Is Null", exception.Message);
    }

    [Fact]
    public void Post_ShouldThrowException_WhenTitleLengthIsGreaterThan100()
    {
        var title = new string('*', 101);
        var content = "Hello World";

        var exception = Assert.Throws<Exception>(() => new Post(title, content));

        Assert.Equal("max title length is 100", exception.Message);
    }
}