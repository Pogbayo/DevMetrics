using DevMetrics.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevMetrics.Infrastructure.Data
{
    public class DevMetricsDbContext : DbContext
    {
        public DevMetricsDbContext(DbContextOptions<DevMetricsDbContext> options)
            : base(options) { }

        //public DbSet<User> Users => Set<User>();
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<Event> Events => Set<Event>();
        public DbSet<UserProject> UserProjects => Set<UserProject>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ============================
            // USER
            // ============================
            //modelBuilder.Entity<User>(entity =>
            //{
            //    entity.HasKey(u => u.Id);

            //    entity.Property(u => u.Username)
            //          .IsRequired()
            //          .HasMaxLength(100);

            //    entity.Property(u => u.Email)
            //          .IsRequired()
            //          .HasMaxLength(200);

            //    // Unique lookups
            //    entity.HasIndex(u => u.Username).IsUnique();
            //    entity.HasIndex(u => u.Email).IsUnique();
            //});

            // ============================
            // PROJECT
            // ============================
            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Name)
                      .IsRequired()
                      .HasMaxLength(150);

                entity.HasIndex(p => p.Name);
            });

            // ============================
            // EVENT
            // ============================
            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.EventType)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.Timestamp)
                      .IsRequired();

                // Relationships
                //entity.HasOne(e => e.User)
                //      .WithMany(u => u.Events)
                //      .HasForeignKey(e => e.UserId)
                //      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Project)
                      .WithMany(p => p.Events)
                      .HasForeignKey(e => e.ProjectId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Indexes for common queries
                entity.HasIndex(e => e.UserId);
                entity.HasIndex(e => e.ProjectId);

                // Analytics queries
                entity.HasIndex(e => new { e.UserId, e.Timestamp });
                entity.HasIndex(e => new { e.ProjectId, e.Timestamp });
                entity.HasIndex(e => new { e.EventType, e.Timestamp });
            });

            // ============================
            // USER PROJECT (JOIN TABLE)
            // ============================
            modelBuilder.Entity<UserProject>(entity =>
            {
                // Composite primary key
                entity.HasKey(up => new { up.UserId, up.ProjectId });

                //entity.HasOne(up => up.User)
                //      .WithMany(u => u.UserProjects)
                //      .HasForeignKey(up => up.UserId);

                entity.HasOne(up => up.Project)
                      .WithMany(p => p.UserProjects)
                      .HasForeignKey(up => up.ProjectId);

                // Needed for reverse lookups
                entity.HasIndex(up => up.ProjectId);
            });
        }
    }
}
