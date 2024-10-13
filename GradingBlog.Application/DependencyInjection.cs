using GradingBlog.Application.Posts.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GradingBlog.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        => services
            .AddServices();

    private static IServiceCollection AddServices(this IServiceCollection services)
        => services
            .AddScoped<IPostService, PostService>();
}