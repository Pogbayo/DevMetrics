using DevMetrics.Application.Interfaces;
using DevMetrics.Domain.Entities;

namespace DevMetrics.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        public Task AddProjectAsync(Project project)
        {
            throw new NotImplementedException();
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
