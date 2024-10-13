using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GradingBlog.DataLayer;

public static class DependencyInjection
{
    public static IServiceCollection AddDataLayerDependencies(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddSqlServer(configuration);

    private static IServiceCollection AddSqlServer(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddSqlServer<DataContext>(configuration.GetConnectionString("GradingBlog"));
}