using DevMetrics.Application.Interfaces;
using DevMetrics.Application.Repositories;
using DevMetrics.Infrastructure.Data;
using DevMetrics.Infrastructure.Repositories;
using DevMetrics.Infrastructure.Shard;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevMetrics.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure DbContext
            services.AddDbContext<DevMetricsDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("Shard1")));

            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<ShardResolver>();
            services.AddScoped<ShardResolver>();

            // Register repositories
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
