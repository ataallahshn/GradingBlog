using System.Reflection;
using GradingBlog.Services.Posts.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GradingBlog.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        => services
            .AddServices()
            .AddMediatR();

    private static IServiceCollection AddMediatR(this IServiceCollection services)
        => services.AddMediatR(options => { options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });

    private static IServiceCollection AddServices(this IServiceCollection services)
        => services
            .AddScoped<IPostService, PostService>();
}