using DevMetrics.Application.Events;
using DevMetrics.Application.Interfaces;
using DevMetrics.Application.Listeners;
using DevMetrics.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DevMetrics.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddSingleton<ProjectEvents>();
            services.AddScoped<CentralMappingListener>();
            return services;
        }
    }
}
