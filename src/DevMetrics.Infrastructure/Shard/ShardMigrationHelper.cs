using DevMetrics.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevMetrics.Infrastructure.Shard
{
    public static class ShardMigrationHelper
    {
        public static async Task ApplyMigrationsAsync(IConfiguration config)
        {
            var connections = new[]
            {
                config.GetConnectionString("Shard1"),
                config.GetConnectionString("Shard2"),
                config.GetConnectionString("Shard3")
            };

            foreach (var connection in connections)
            {
                var options = new DbContextOptionsBuilder<DevMetricsDbContext>()
                    .UseSqlServer(connection)
                    .Options;

                using var context = new DevMetricsDbContext(options);
                await context.Database.MigrateAsync();
            }
        }
    }
}
