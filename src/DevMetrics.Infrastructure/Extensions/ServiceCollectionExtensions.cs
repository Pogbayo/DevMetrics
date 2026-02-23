using System.Text;
using DevMetrics.Application.Interfaces;
using DevMetrics.Infrastructure.Data;
using DevMetrics.Infrastructure.JWT;
using DevMetrics.Infrastructure.Repositories;
using DevMetrics.Infrastructure.Services;
using DevMetrics.Infrastructure.Shard;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace DevMetrics.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AuthDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("AuthDatabase")));

            services.AddDbContext<CentralDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("CentralDb")));

            services.AddDbContext<DevMetricsDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("Shard1")));

            services.Configure<JwtSetting>(
                configuration.GetSection("Jwt"));

            var jwtSettings = configuration
                .GetSection("Jwt")
                .Get<JwtSetting>();

            var key = Encoding.UTF8.GetBytes(jwtSettings!.Key);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters =
                        new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = jwtSettings.Issuer,
                            ValidAudience = jwtSettings.Audience,
                            IssuerSigningKey =
                                new SymmetricSecurityKey(key)
                        };
                });

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));

            services.AddAuthorization();

            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddSingleton<ShardResolver>();
            services.AddScoped<ShardedDbContextFactory>();

            services.AddScoped<ITokenGenerator, TokenGenerator>();

            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}