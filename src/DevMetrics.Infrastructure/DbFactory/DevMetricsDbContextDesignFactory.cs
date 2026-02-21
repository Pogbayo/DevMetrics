using DevMetrics.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DevMetrics.Infrastructure.DbFactory
{ 
    public class DevMetricsDbContextDesignFactory
     : IDesignTimeDbContextFactory<DevMetricsDbContext>
    {
        public DevMetricsDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var connectionString = configuration.GetConnectionString("Shard1");

            var optionsBuilder = new DbContextOptionsBuilder<DevMetricsDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return new DevMetricsDbContext(optionsBuilder.Options);
        }
    }
}