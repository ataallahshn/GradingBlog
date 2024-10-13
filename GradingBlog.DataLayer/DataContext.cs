using Microsoft.EntityFrameworkCore;

namespace GradingBlog.DataLayer;

public sealed class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
}