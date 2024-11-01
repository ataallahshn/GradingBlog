using GradingBlog.DataLayer.Posts.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GradingBlog.DataLayer;

public static class DependencyInjection
{
    public static IServiceCollection AddDataLayerDependencies(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddSqlServer(configuration)
            .AddUnitOfWork()
            .AddRepositories();

    private static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        => services.AddScoped<IUnitOfWork, UnitOfWork>();

    private static IServiceCollection AddRepositories(this IServiceCollection services)
        => services
            .AddScoped<IPostRepository, PostRepository>()
            .AddScoped<IPostHistoryRepository, PostHistoryRepository>()
            .AddScoped<ICommentRepository, CommentRepository>();

    private static IServiceCollection AddSqlServer(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddSqlServer<DataContext>(configuration.GetConnectionString("GradingBlog"));
}