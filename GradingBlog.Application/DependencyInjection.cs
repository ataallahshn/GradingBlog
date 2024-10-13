using Microsoft.Extensions.DependencyInjection;

namespace GradingBlog.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        => services;
}