using Microsoft.EntityFrameworkCore;
using DevMetrics.Infrastructure.Data;

namespace DevMetrics.Infrastructure.Shard
{
    public class ShardedDbContextFactory
    {
        private readonly ShardResolver _resolver;

        public ShardedDbContextFactory(ShardResolver resolver)
        {
            _resolver = resolver;
        }

        public DevMetricsDbContext Create(Guid userId)
        {
            var connectionString = _resolver.Resolve(userId);

            var options = new DbContextOptionsBuilder<DevMetricsDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            return new DevMetricsDbContext(options);
        }
    }
}
