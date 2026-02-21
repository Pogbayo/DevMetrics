using Microsoft.Extensions.Configuration;

namespace DevMetrics.Infrastructure.Shard
{
    public class ShardResolver
    {
        private readonly IConfiguration _config;

        public ShardResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Guid userId)
        {
            var shardNumber = Math.Abs(userId.GetHashCode()) % 3;

            var connectionString = shardNumber switch
            {
                0 => _config.GetConnectionString("Shard1"),
                1 => _config.GetConnectionString("Shard2"),
                2 => _config.GetConnectionString("Shard3"),
                _ => throw new Exception("Invalid shard")
            };

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException($"Connection string for shard {shardNumber + 1} is not configured.");
            }

            return connectionString;
        }
    }

}
