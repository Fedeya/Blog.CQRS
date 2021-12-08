using Blog.Application.Common.Interfaces;
using Blog.Infrastructure.Persistence;
using Blog.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<BlogDbContext>(options =>
        {
            options.EnableSensitiveDataLogging();
            options.UseInMemoryDatabase("BlogDb");
        });

        services.AddScoped<IBlogDbContext>(provider => provider.GetRequiredService<BlogDbContext>());

        services.AddTransient<IDateTime, DateTimeService>();

        return services;
    }
}