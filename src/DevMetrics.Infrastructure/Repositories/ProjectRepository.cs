using DevMetrics.Application.Interfaces;
using DevMetrics.Domain.Entities;
using DevMetrics.Infrastructure.Data;
using DevMetrics.Infrastructure.Shard;

namespace DevMetrics.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ShardedDbContextFactory _factory;
        private readonly ICurrentUserService _currentUser;
        private readonly AuthDbContext _context;
        private readonly CentralDbContext _centralDbContext;
        public ProjectRepository(ShardedDbContextFactory factory, ICurrentUserService currentUser, AuthDbContext context, CentralDbContext centralDbContext)
        {
            _factory = factory;
            _currentUser = currentUser;
            _context = context;
            _centralDbContext = centralDbContext;
        }
        public Task AddProjectAsync(Project project)
        {

        }

        public Task<List<Project>> GetAllProjectsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Project?> GetProjectByIdAsync(Guid projectId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Project>> GetProjectsByUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Project>> GetProjectsWithNoUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<Guid, int>> GetProjectUserCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalProjectCountAsync()
        {
            throw new NotImplementedException();
        }
    }
}
