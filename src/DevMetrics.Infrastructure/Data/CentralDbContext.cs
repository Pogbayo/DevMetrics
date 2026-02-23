using DevMetrics.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevMetrics.Infrastructure.Data
{
    public class CentralDbContext : DbContext
    {
        public CentralDbContext(DbContextOptions<CentralDbContext> options)
            : base(options) { }

        public DbSet<UserProject> UserProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.Entity<UserProject>(entity =>
            {
                // Composite primary key
                entity.HasKey(up => new { up.UserId, up.ProjectId });

                //entity.HasOne(up => up.User)
                //      .WithMany(u => u.UserProjects)
                //      .HasForeignKey(up => up.UserId);

                //entity.HasOne(up => up.Project)
                //      .WithMany(p => p.UserProjects)
                //      .HasForeignKey(up => up.ProjectId);

                entity.HasIndex(up => up.ProjectId);
            });
        }
    }
}
