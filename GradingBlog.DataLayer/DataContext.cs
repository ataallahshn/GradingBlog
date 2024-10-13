using GradingBlog.DataLayer.Posts;
using Microsoft.EntityFrameworkCore;

namespace GradingBlog.DataLayer;

public sealed class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(assembly: typeof(DataContext).Assembly);
    }

    public DbSet<Post> Posts { get; set; }

    public DbSet<Comment> Comments { get; set; }

    public DbSet<PostHistory> PostHistories { get; set; }
}