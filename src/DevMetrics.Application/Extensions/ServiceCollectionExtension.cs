using DevMetrics.Application.Interfaces;
using DevMetrics.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DevMetrics.Application.Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        return services;
    }
}
